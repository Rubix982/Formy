namespace StudentDataRecord.StudentDataRecord.Models.Entities
{
    internal class Student
    {
        public Student(
            string? id,
            string name,
            string address,
            string phone,
            string email,
            string course,
            string year,
            string age)
        {
            Id = id;
            Name = name;
            Address = address;
            Phone = phone;
            Email = email;
            Course = course;
            Year = year;
            Age = age;
        }

        public Student()
        {
            Id = "";
            Address = "";
            Phone = "";
            Email = "";
            Course = "";
            Year = "";
            Age = "";
            Name = "";
        }

        public string? Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Course { get; set; }
        public string Year { get; set; }
        public string Age { get; set; }

        public static List<string> GetPropertyList()
        {
            return new List<string>() { "Id", "Name", "Address", "Phone", "Email", "Course", "Year", "Age" };
        }

        public bool Equals(Student student)
        {
            return Id == student.Id && Name == student.Name &&
                   Address == student.Address && Phone == student.Phone &&
                   Email == student.Email && Course == student.Course &&
                   Year == student.Year && Age == student.Age;
        }
    }
}
