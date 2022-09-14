using StudentDataRecord.StudentDataRecord.Models.Entities;
using StudentDataRecord.StudentDataRecord.Models.Creation;
using StudentDataRecord.Tests.Config;

namespace StudentDataRecord.Tests.Models.Creation
{
    public class TestXlsxWorkbook
    {
        [Fact]
        public void TestXlsxWorkbookCreation()
        {
            var xlsxFilePath = CreateXlsxWorkbook();

            Assert.True(File.Exists(xlsxFilePath), "Excel file created successfully");
        }

        private string CreateXlsxWorkbook()
        {
            var filePathConfig = ConfTest.GetFilePathConfig();

            var xlsxFolderPath = Path.Join(filePathConfig["userProfileFilePath"], filePathConfig["defaultXlsxWorkbookFolderName"]);
            
            var xlsxFilePath = Path.Join(xlsxFolderPath, filePathConfig["defaultXlsxWorkbookFileName"]);

            CleanDirectoryForTest(xlsxFilePath, xlsxFolderPath);

            var xlsxWorkbook = new XlsxWorkbook<Student>(Student.GetPropertyList(), xlsxFilePath, true);

            xlsxWorkbook.CreateWorkBook("StudentDataRecord", "TestXlsxWorkbookCreation");

            return xlsxFilePath;
        }

        private static void CleanDirectoryForTest(string xlsxFilePath, string xlsxFolderPath)
        {
            if (File.Exists(xlsxFilePath))
            {
                File.Delete(xlsxFilePath);
            }

            if (Directory.Exists(xlsxFolderPath))
            {
                Directory.Delete(xlsxFolderPath, true);
            }

            Directory.CreateDirectory(xlsxFolderPath);
        }

        [Fact]
        private void TestXlsxWorkbookWrite()
        {
            var xlsxFilePath = CreateXlsxWorkbook();

            var xlsxWorkbook = new XlsxWorkbook<Student>(Student.GetPropertyList(), xlsxFilePath, true);

            var students = ConfTest.GetStudentDummyData();
            
            xlsxWorkbook.WriteToSheet(students);

            var studentsRead = xlsxWorkbook.ReadWorkBook();

            Assert.True(AreStudentListsSame(students, studentsRead) , "Students written to Excel file are same as read from Excel file");
        }

        private static bool AreStudentListsSame(IReadOnlyCollection<Student> students, IReadOnlyList<Student> studentsRead)
        {
            if (students.Count() != studentsRead.Count)
            {
                throw new ArgumentException("Students and studentsRead are not of same length!");
            }

            for (var i = 0; i < students.Count(); i++)
            {
                if (!students.ElementAt(i).Equals((studentsRead[i])))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
