using SkiaSharp;
using Svg.Skia;
using System.Text;

namespace GrblExpress.ImgToGCode
{
    public class ImageToGCodeConverter
    {
        public static SKBitmap LoadBitmap(string path)
        {
            // Load the image using SkiaSharp
            var img = SKImage.FromEncodedData(path);
            if (img == null)
            {
                throw new Exception("Unsupported image format or corrupted file.");
            }
            var bitmap = SKBitmap.FromImage(img);
            if (bitmap == null)
            {
                throw new Exception("Unsupported image format or corrupted file.");
            }
            return bitmap;
        }

        public static SKSvg LoadSvg(string path)
        {
            // Load the SVG using SkiaSharp
            var svg = new SKSvg();
            svg.Load(path);
            return svg;
        }

        public static BitmapColorType GetBitmapColorType(SKBitmap bitmap)
        {
            bool isColor = false;
            bool isGrayscale = true;

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    var color = bitmap.GetPixel(x, y);
                    if (color.Red != color.Green || color.Green != color.Blue)
                    {
                        isGrayscale = false;
                        isColor = true;
                        break;
                    }
                    if (color.Red != 0 && color.Red != 255)
                    {
                        isColor = true;
                    }
                }
                if (isColor && !isGrayscale)
                {
                    break;
                }
            }

            if (!isColor)
            {
                return BitmapColorType.BlackAndWhite;
            }
            else if (isGrayscale)
            {
                return BitmapColorType.Grayscale;
            }
            else
            {
                return BitmapColorType.Color;
            }
        }

        public static SKBitmap ConvertToGrayscale(SKBitmap bitmap)
        {
            var grayscaleBitmap = new SKBitmap(bitmap.Width, bitmap.Height);

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    var color = bitmap.GetPixel(x, y);
                    var brightness = (byte)(0.299 * color.Red + 0.587 * color.Green + 0.114 * color.Blue);
                    var grayColor = new SKColor(brightness, brightness, brightness, color.Alpha);
                    grayscaleBitmap.SetPixel(x, y, grayColor);
                }
            }

            return grayscaleBitmap;
        }

        public static SKBitmap FlipBitmap(SKBitmap bitmap, bool flipHorizontal, bool flipVertical)
        {
            var flippedBitmap = new SKBitmap(bitmap.Width, bitmap.Height);
            using (var canvas = new SKCanvas(flippedBitmap))
            {
                var matrix = SKMatrix.CreateScale(
                    flipHorizontal ? -1 : 1,
                    flipVertical ? -1 : 1,
                    bitmap.Width / 2f,
                    bitmap.Height / 2f);
                canvas.SetMatrix(matrix);
                canvas.DrawBitmap(bitmap, 0, 0);
            }
            return flippedBitmap;
        }

        // This only looks like it is increasing the canvas size not actually scaling the image
        public static SKBitmap ScaleBitmap(SKBitmap bitmap, float scaleX, float scaleY)
        {
            var scaledWidth = (int)(bitmap.Width * scaleX);
            var scaledHeight = (int)(bitmap.Height * scaleY);
            var scaledBitmap = new SKBitmap(scaledWidth, scaledHeight);
            using (var canvas = new SKCanvas(scaledBitmap))
            {
                var destRect = new SKRect(0, 0, scaledWidth, scaledHeight);
                canvas.DrawBitmap(bitmap, destRect);
            }
            return scaledBitmap;
        }

        public static SKBitmap RotateBitmap(SKBitmap bitmap, float rotationDegrees)
        {
            var rotatedBitmap = new SKBitmap(bitmap.Width, bitmap.Height);
            using (var canvas = new SKCanvas(rotatedBitmap))
            {
                var matrix = SKMatrix.CreateRotationDegrees(
                    rotationDegrees,
                    bitmap.Width / 2f,
                    bitmap.Height / 2f);
                canvas.SetMatrix(matrix);
                canvas.DrawBitmap(bitmap, 0, 0);
            }
            return rotatedBitmap;
        }

        public static string ConvertBitmapToRasterGCode(
            SKBitmap bitmap,
            bool includePreamble = true,
            string laserOnGCode = "M106", // or M3
            string laserOffGCode = "M107", // or M5
            float tolerance = 0.05f,
            float feedRate = 1000f,
            int laserMinPower = 0,
            int laserMaxPower = 255,
            bool useLaserOnOffCommands = false,
            bool useRelativeCoordinates = false,
            UnitsType units = UnitsType.Millimeters)
        {
            // Initialize G-code commands
            var gcode = new StringBuilder();

            // Setup G-code preamble
            if (includePreamble)
            {
                gcode.AppendLine(units == UnitsType.Millimeters ? "G21 ; Set units to millimeters" : "G20 ; Set units to inches");
                gcode.AppendLine(useRelativeCoordinates ? "G91 ; Use relative coordinates" : "G90 ; Use absolute coordinates");
                gcode.AppendLine("G28 ; Home all axes");
            }

            // Variables to track current position
            int currentX = 0;
            int currentY = 0;

            // Iterate over image rows (Y axis)
            for (int y = 0; y < bitmap.Height; y++)
            {
                bool isForward = y % 2 == 0;
                int startX = isForward ? 0 : bitmap.Width - 1;
                int endX = isForward ? bitmap.Width : -1;
                int stepX = isForward ? 1 : -1;

                // Ensure the laser is off before moving to the next row
                gcode.AppendLine($"{laserOffGCode} ; Turn off laser");

                // Calculate movement to the start of the line
                int moveX = useRelativeCoordinates ? startX - currentX : startX;
                int moveY = useRelativeCoordinates ? y - currentY : y;

                // Move to the start of the line
                gcode.AppendLine($"G0 X{moveX} Y{moveY}");

                currentX = startX;
                currentY = y;

                // Turn the laser back on if not using laser on/off commands
                if (!useLaserOnOffCommands)
                    gcode.AppendLine($"{laserOnGCode} ; Turn on laser");

                int x = startX;
                bool laserOn = !useLaserOnOffCommands;

                while (x != endX)
                {
                    // Get the current pixel's laser power
                    var pixelColor = bitmap.GetPixel(x, y);
                    var brightness = GetBrightness(pixelColor);
                    int laserPower = (int)((1 - brightness) * (laserMaxPower - laserMinPower)) + laserMinPower;

                    int runStartX = x;

                    // Look ahead to group pixels with similar laser power
                    while (true)
                    {
                        int nextX = x + stepX;
                        if (nextX == endX)
                            break;

                        var nextPixelColor = bitmap.GetPixel(nextX, y);
                        var nextBrightness = GetBrightness(nextPixelColor);
                        int nextLaserPower = (int)((1 - nextBrightness) * (laserMaxPower - laserMinPower)) + laserMinPower;

                        if (Math.Abs(laserPower - nextLaserPower) > tolerance * (laserMaxPower - laserMinPower))
                            break;

                        x = nextX;
                    }

                    int runEndX = x;

                    // Calculate movement
                    moveX = useRelativeCoordinates ? runEndX - currentX : runEndX;
                    moveY = 0;

                    // Determine whether to use laser on/off commands
                    if (useLaserOnOffCommands)
                    {
                        if (laserPower < laserMinPower)
                        {
                            if (laserOn)
                            {
                                gcode.AppendLine($"{laserOffGCode} ; Turn off laser");
                                laserOn = false;
                            }
                        }
                        else
                        {
                            if (!laserOn)
                            {
                                gcode.AppendLine($"{laserOnGCode} ; Turn on laser");
                                laserOn = true;
                            }
                            gcode.AppendLine($"G1 X{moveX} Y{moveY} S{laserPower} F{feedRate}");
                        }
                    }
                    else
                    {
                        gcode.AppendLine($"G1 X{moveX} Y{moveY} S{laserPower} F{feedRate}");
                    }

                    currentX = runEndX;
                    x += stepX;
                }

                // Ensure the laser is off at the end of the row
                if (laserOn)
                {
                    gcode.AppendLine($"{laserOffGCode} ; Turn off laser");
                    laserOn = false;
                }
            }

            // Finish the program
            if (includePreamble)
            {
                // Move back to origin if using relative coordinates
                if (useRelativeCoordinates)
                    gcode.AppendLine($"G0 X{-currentX} Y{-currentY} ; Move to origin");
                else
                    gcode.AppendLine("G0 X0 Y0 ; Move to origin");

                gcode.AppendLine("G28 ; Home all axes");
                gcode.AppendLine("M2 ; End of program");
            }

            return gcode.ToString();
        }

        private static float GetBrightness(SKColor color)
        {
            // Calculate brightness using standard luminance formula and alpha channel
            float alpha = color.Alpha / 255f;
            float brightness = (0.299f * color.Red + 0.587f * color.Green + 0.114f * color.Blue) / 255f;
            return brightness * alpha;
        }
    }
}
