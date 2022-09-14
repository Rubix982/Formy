using System;
using System.Linq.Expressions;
using StudentDataRecord.StudentDataRecord.Models.Entities;

namespace StudentDataRecord.Tests.Models.Entities
{
    public class TestStudent
    {
        [Fact]
        public void TestStudentCreation()
        {
            var student = new Student("1", "John",
                "123 Main St", "123-456-7890",
                "john@email.com", "CS6001", "2023",
                "23");

            Assert.Equal("1", student.Id);
            Assert.Equal("John", student.Name);
            Assert.Equal("123 Main St", student.Address);
            Assert.Equal("123-456-7890", student.Phone);
            Assert.Equal("john@email.com", student.Email);
            Assert.Equal("CS6001", student.Course);
            Assert.Equal("2023", student.Year);
            Assert.Equal("23", student.Age);
        }

        [Fact]
        public void TestStudentPropertyList()
        {
            Assert.Equal(8, Student.GetPropertyList().Count);
            Assert.Equal(new List<string>() { "Id", "Name", "Address", 
                    "Phone", "Email", "Course", "Year", "Age" },
                Student.GetPropertyList());
        }

        [Fact]
        public void TestStudentEquality()
        {
            var studentOne = new Student("1", "John", 
                "123 Main St", "123-456-7890", 
                "john@email.com", "CS6001", "2023", 
                "23");
            
            var studentTwo = new Student("1", "John", 
                "123 Main St", "123-456-7890", 
                "john@email.com", "CS6001", "2023", 
                "23");

            Assert.True(studentOne.Equals(studentTwo), "studentOne.Equals(studentTwo)");
        }
    }
}
