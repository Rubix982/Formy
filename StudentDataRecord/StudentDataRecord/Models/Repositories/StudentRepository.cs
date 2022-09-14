// StudentDataRecord imports

using StudentDataRecord.StudentDataRecord.Models.Interfaces;
using StudentDataRecord.StudentDataRecord.Models.Creation;
using StudentDataRecord.StudentDataRecord.Models.Entities;

namespace StudentDataRecord.StudentDataRecord.Models.Repositories
{
    internal sealed class StudentRepository : IRepository<Student>
    { 
        // Path variables
        private static readonly string? UserProfile = Environment.GetEnvironmentVariable("USERPROFILE");
        private const string DefaultFolderName = "StudentDataRecordProject";
        private const string DefaultXlsxFileName = "StudentDataRecord.xlsx";
        private static string _folderPath = Path.Join(UserProfile, DefaultFolderName); 
        private static string _xlsxFilePath = Path.Join(_folderPath, DefaultXlsxFileName);

        // Singleton variables
        public static StudentRepository? Instance { get; private set; }
        private static readonly object Lock = new();

        // XLSXWorkbook injection
        private XlsxWorkbook<Student>? _studentWorkbook;
        
        // Actual list of students
        private List<Student>? StudentList { get; set; }

        // Properties of the student object
        private List<string>? PropertyList { get; set; }

        private StudentRepository(List<string>? propertyList, string? folderPath, string? xlsxFileName)
        {
            Initialize(propertyList, folderPath, xlsxFileName);
        }

        public static StudentRepository GetStudentRepositoryInstance(List<string>? propertyList, string? folderPath, string? xlsxFileName)
        {
            if (Instance != null) return Instance;
            
            lock (Lock)
            {
                Instance ??= new StudentRepository(propertyList, folderPath, xlsxFileName);
            }

            return Instance;
        }

        public static List<string> GetPropertyList()
        {
            return Student.GetPropertyList();
        }

        private void Initialize(List<string>? propertyList, string? folderPath, string? xlsxFileName)
        {
            PropertyList = propertyList;

            if (folderPath != null)
            {
                _folderPath = folderPath;
                _xlsxFilePath = Path.Join(folderPath, xlsxFileName ?? DefaultXlsxFileName);
            }
            
            _studentWorkbook = new XlsxWorkbook<Student>(PropertyList, _xlsxFilePath, true);

            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
                CreateWorkbook(_studentWorkbook);
            }
            else
            {
                if (!File.Exists(_xlsxFilePath))
                {
                    CreateWorkbook(_studentWorkbook);
                }
                else
                {
                    StudentList = _studentWorkbook.ReadWorkBook();
                    IndexCounter = StudentList.Count + 1;
                }
            }
        }

        private void CreateWorkbook(XlsxWorkbook<Student> xlsxWorkbookStudent)
        {
            xlsxWorkbookStudent.CreateWorkBook("Saif Ul Islam", "student_records");

            StudentList = new List<Student>();
            IndexCounter = 1;
        }

        public long? IndexCounter { get; set;  }

        public void Add(Student entity)
        {
            entity.Id = IndexCounter.ToString();
            StudentList!.Add(entity);
            IndexCounter += 1;
        }

        public void DeleteByEntity(Student entity)
        {
            StudentList!.Remove(entity);
        }

        public void DeleteByIndex(int index)
        {
            StudentList!.RemoveAt(index);
        }
        
        public List<Student>? GetAll()
        {
            return StudentList;
        }

        public Student GetById(int id)
        {
            foreach (var student in StudentList!.Where(student => student.Id == id.ToString()))
            {
                return student;
            }

            throw new KeyNotFoundException($"No student record with ID {id}");
        }

        public void WriteToExcel()
        {
            _studentWorkbook!.WriteToSheet(StudentList);
        }
    }
}
