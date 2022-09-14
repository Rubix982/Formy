using StudentDataRecord.StudentDataRecord.Models.Entities;

namespace StudentDataRecord.Tests.Config
{
    internal class ConfTest
    {

        public static Dictionary<string, string?> GetFilePathConfig()
        {
            var config = new Dictionary<string, string?>
            {
                { "executableFilePath", @"C:\\Users\\saif.islam\\source\\repos\\
                        StudentDataRecord\\StudentDataRecord\\bin\\Debug\\net6.0-windows
                        \\StudentDataRecord.exe" },
                { "userProfileFilePath", Environment.GetEnvironmentVariable("USERPROFILE") },
                { "defaultXlsxWorkbookFolderName", "StudentDataRecordProject" },
                { "defaultXlsxWorkbookFileName", "TestStudentDataRecord.xlsx" }
            };

            ValidateConfig(config);

            return config;
        }

        public static List<Student> GetStudentDummyData()
        {
            var students = new List<Student>
            {
                new Student("1", "Saif", "ABC", "123", "saifulislam84210@gmail.com", "CS6001", "2022", "23"),
                new Student("2", "Saif", "ABC", "123", "saifulislam84210@gmail.com", "CS6002", "2022", "23"),
                new Student("3", "Saif", "ABC", "123", "saifulislam84210@gmail.com", "CS6003", "2022", "23"),
                new Student("4", "Saif", "ABC", "123", "saifulislam84210@gmail.com", "CS6004", "2002", "23"),
            };

            return students;
        }

        private static void ValidateConfig(Dictionary<string, string?> config)
        {
            foreach (var key in config.Keys.Where(key => IsInvalid(config[key]))) 
            {
                throw new ArgumentNullException($"Config key {key} is null or an empty string. Value is {config[key]}");
            }
        }

        private static bool IsInvalid(string? value)
        {
            return string.IsNullOrEmpty(value);
        }
    }
}
