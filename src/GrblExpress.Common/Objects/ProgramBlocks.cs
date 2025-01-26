using CommunityToolkit.Mvvm.ComponentModel;

namespace GrblExpress.Common.Objects
{
    public class ProgramBlocks : ObservableObject
    {
        private List<ProgramBlock> _blocks = new();
        public List<ProgramBlock> Blocks
        {
            get => _blocks;
            set => SetProperty(ref _blocks, value);
        }

        public static ProgramBlocks LoadDemoData()
        {
            return new ProgramBlocks
            {
                Blocks = new List<ProgramBlock>
                {
                    new ProgramBlock { Index = 1, Data = "G21" },
                    new ProgramBlock { Index = 2, Data = "G90" },
                    new ProgramBlock { Index = 3, Data = "G0 X0 Y0 Z0" },
                    new ProgramBlock { Index = 4, Data = "G1 X10 F100" },
                    new ProgramBlock { Index = 5, Data = "G1 Y10 F100" },
                    new ProgramBlock { Index = 6, Data = "G1 X0 F100" },
                    new ProgramBlock { Index = 7, Data = "G1 Y0 F100" },
                    new ProgramBlock { Index = 8, Data = "G0 Z10" },
                    new ProgramBlock { Index = 9, Data = "G1 X20 Y20 F200" },
                    new ProgramBlock { Index = 10, Data = "G1 X10 Y10 F200" },
                    new ProgramBlock { Index = 11, Data = "G0 Z5" },
                    new ProgramBlock { Index = 12, Data = "G1 X30 Y30 F300" },
                    new ProgramBlock { Index = 13, Data = "G1 X15 Y15 F300" },
                    new ProgramBlock { Index = 14, Data = "G0 Z0" },
                    new ProgramBlock { Index = 15, Data = "G1 X40 Y40 F400" },
                    new ProgramBlock { Index = 16, Data = "G1 X20 Y20 F400" },
                    new ProgramBlock { Index = 17, Data = "G0 Z10" },
                    new ProgramBlock { Index = 18, Data = "G1 X50 Y50 F500" },
                    new ProgramBlock { Index = 19, Data = "G1 X25 Y25 F500" },
                    new ProgramBlock { Index = 20, Data = "G0 Z15" },
                    new ProgramBlock { Index = 21, Data = "G1 X60 Y60 F600" },
                    new ProgramBlock { Index = 22, Data = "G1 X30 Y30 F600" },
                    new ProgramBlock { Index = 23, Data = "G0 Z20" },
                    new ProgramBlock { Index = 24, Data = "G1 X70 Y70 F700" },
                    new ProgramBlock { Index = 25, Data = "G1 X35 Y35 F700" },
                    new ProgramBlock { Index = 26, Data = "G0 Z25" },
                    new ProgramBlock { Index = 27, Data = "G1 X80 Y80 F800" },
                    new ProgramBlock { Index = 28, Data = "G1 X40 Y40 F800" },
                    new ProgramBlock { Index = 29, Data = "G0 Z30" },
                    new ProgramBlock { Index = 30, Data = "G1 X90 Y90 F900" },
                    new ProgramBlock { Index = 31, Data = "G1 X45 Y45 F900" },
                    new ProgramBlock { Index = 32, Data = "G0 Z35" },
                    new ProgramBlock { Index = 33, Data = "G1 X100 Y100 F1000" },
                    new ProgramBlock { Index = 34, Data = "G1 X50 Y50 F1000" },
                    new ProgramBlock { Index = 35, Data = "G0 Z40" },
                    new ProgramBlock { Index = 36, Data = "G1 X110 Y110 F1100" },
                    new ProgramBlock { Index = 37, Data = "G1 X55 Y55 F1100" },
                    new ProgramBlock { Index = 38, Data = "G0 Z45" },
                    new ProgramBlock { Index = 39, Data = "G1 X120 Y120 F1200" },
                    new ProgramBlock { Index = 40, Data = "G1 X60 Y60 F1200" },
                    new ProgramBlock { Index = 41, Data = "G0 Z50" },
                    new ProgramBlock { Index = 42, Data = "G1 X130 Y130 F1300" },
                    new ProgramBlock { Index = 43, Data = "G1 X65 Y65 F1300" },
                    new ProgramBlock { Index = 44, Data = "G0 Z55" },
                    new ProgramBlock { Index = 45, Data = "G1 X140 Y140 F1400" },
                    new ProgramBlock { Index = 46, Data = "G1 X70 Y70 F1400" },
                    new ProgramBlock { Index = 47, Data = "G0 Z60" },
                    new ProgramBlock { Index = 48, Data = "G1 X150 Y150 F1500" },
                    new ProgramBlock { Index = 49, Data = "G1 X75 Y75 F1500" },
                    new ProgramBlock { Index = 50, Data = "M30" }
                }
            };
        }

        public static ProgramBlocks Load(string program)
        {
            var lines = program.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            var blocks = lines.Select((line, index) => new ProgramBlock { Index = index + 1, Data = line }).ToList();

            return new ProgramBlocks
            {
                Blocks = blocks
            };
        }
    }
}
