using CommunityToolkit.Mvvm.ComponentModel;

namespace GrblExpress.Common.Objects
{
    public class SDCardFiles : ObservableObject
    {
        private List<SDCardFile> _files = new();
        public List<SDCardFile> Files
        {
            get => _files;
            set => SetProperty(ref _files, value);
        }

        public static SDCardFiles LoadDemoData()
        {
            var random = new Random();
            return new SDCardFiles
            {
                Files = new List<SDCardFile>
                {
                    new SDCardFile { Name = "File1_name.txt", Size = "1000", Date = DateTimeOffset.UtcNow.AddDays(-random.Next(128)).ToString() },
                    new SDCardFile { Name = "File2_name.txt", Size = "2000", Date = DateTimeOffset.UtcNow.AddDays(-random.Next(128)).ToString() },
                    new SDCardFile { Name = "File3_name.txt", Size = "3000", Date = DateTimeOffset.UtcNow.AddDays(-random.Next(128)).ToString() },
                    new SDCardFile { Name = "File4_name.txt", Size = "4000", Date = DateTimeOffset.UtcNow.AddDays(-random.Next(128)).ToString() },
                    new SDCardFile { Name = "File5_name.txt", Size = "5000", Date = DateTimeOffset.UtcNow.AddDays(-random.Next(128)).ToString() },
                    new SDCardFile { Name = "File6_name.txt", Size = "6000", Date = DateTimeOffset.UtcNow.AddDays(-random.Next(128)).ToString() },
                    new SDCardFile { Name = "File7_name.txt", Size = "7000", Date = DateTimeOffset.UtcNow.AddDays(-random.Next(128)).ToString() },
                    new SDCardFile { Name = "File8_name.txt", Size = "8000", Date = DateTimeOffset.UtcNow.AddDays(-random.Next(128)).ToString() },
                    new SDCardFile { Name = "File9_name.txt", Size = "9000", Date = DateTimeOffset.UtcNow.AddDays(-random.Next(128)).ToString() },
                    new SDCardFile { Name = "File10_name.txt", Size = "10000", Date = DateTimeOffset.UtcNow.AddDays(-random.Next(128)).ToString() },
                    new SDCardFile { Name = "File11_name.txt", Size = "11000", Date = DateTimeOffset.UtcNow.AddDays(-random.Next(128)).ToString() },
                    new SDCardFile { Name = "File12_name.txt", Size = "12000", Date = DateTimeOffset.UtcNow.AddDays(-random.Next(128)).ToString() },
                    new SDCardFile { Name = "File13_name.txt", Size = "13000", Date = DateTimeOffset.UtcNow.AddDays(-random.Next(128)).ToString() },
                    new SDCardFile { Name = "File14_name.txt", Size = "14000", Date = DateTimeOffset.UtcNow.AddDays(-random.Next(128)).ToString() },
                    new SDCardFile { Name = "File15_name.txt", Size = "15000", Date = DateTimeOffset.UtcNow.AddDays(-random.Next(128)).ToString() },
                    new SDCardFile { Name = "File16_name.txt", Size = "16000", Date = DateTimeOffset.UtcNow.AddDays(-random.Next(128)).ToString() },
                    new SDCardFile { Name = "File17_name.txt", Size = "17000", Date = DateTimeOffset.UtcNow.AddDays(-random.Next(128)).ToString() },
                    new SDCardFile { Name = "File18_name.txt", Size = "18000", Date = DateTimeOffset.UtcNow.AddDays(-random.Next(128)).ToString() },
                    new SDCardFile { Name = "File19_name.txt", Size = "19000", Date = DateTimeOffset.UtcNow.AddDays(-random.Next(128)).ToString() },
                    new SDCardFile { Name = "File20_name.txt", Size = "20000", Date = DateTimeOffset.UtcNow.AddDays(-random.Next(128)).ToString() },
                    new SDCardFile { Name = "File21_name.txt", Size = "21000", Date = DateTimeOffset.UtcNow.AddDays(-random.Next(128)).ToString() },
                    new SDCardFile { Name = "File22_name.txt", Size = "22000", Date = DateTimeOffset.UtcNow.AddDays(-random.Next(128)).ToString() },
                    new SDCardFile { Name = "File23_name.txt", Size = "23000", Date = DateTimeOffset.UtcNow.AddDays(-random.Next(128)).ToString() },
                    new SDCardFile { Name = "File24_name.txt", Size = "24000", Date = DateTimeOffset.UtcNow.AddDays(-random.Next(128)).ToString() },
                    new SDCardFile { Name = "File25_name.txt", Size = "25000", Date = DateTimeOffset.UtcNow.AddDays(-random.Next(128)).ToString() },
                    new SDCardFile { Name = "File26_name.txt", Size = "26000", Date = DateTimeOffset.UtcNow.AddDays(-random.Next(128)).ToString() },
                    new SDCardFile { Name = "File27_name.txt", Size = "27000", Date = DateTimeOffset.UtcNow.AddDays(-random.Next(128)).ToString() },
                    new SDCardFile { Name = "File28_name.txt", Size = "28000", Date = DateTimeOffset.UtcNow.AddDays(-random.Next(128)).ToString() },
                    new SDCardFile { Name = "File29_name.txt", Size = "29000", Date = DateTimeOffset.UtcNow.AddDays(-random.Next(128)).ToString() },
                    new SDCardFile { Name = "File30_name.txt", Size = "30000", Date = DateTimeOffset.UtcNow.AddDays(-random.Next(128)).ToString() }
                }
            };
        }

        public static SDCardFiles Load(string files)
        {
            throw new NotImplementedException();
        }
    }
}
