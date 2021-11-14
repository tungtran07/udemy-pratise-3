using System.Collections.Generic;
using System.Linq;
using DLL.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
    public class StudentController : MainApiController
    {
        [HttpGet]
        public IActionResult GetAll([FromQuery] string rollNumber, [FromQuery] string nickName)
        {
            return Ok(StudentStatic.GetAllStudent());
        }

        [HttpGet(template: "{email}")]
        public IActionResult GetA(string email)
        {
            return Ok(StudentStatic.GetAStudent(email));
        }

        [HttpPost]
        public IActionResult Insert([FromForm] Student department)
        {
            return Ok(StudentStatic.InsertStudent(department));
        }

        [HttpPut("{code}")]
        public IActionResult Update(string code, Student department)
        {
            return Ok(StudentStatic.UpdateStudent(code, department));
        }

        [HttpDelete(template:"{code}")]
        public IActionResult Delete(string code)
        {
            return Ok(StudentStatic.DeleteStudent(code));
        }
    }
    
    public static class StudentStatic
    {
        public static List<Student> AllStudent { get; set; } = new List<Student>();

        public static Student InsertStudent(Student department)
        {
            AllStudent.Add(department);
            return department;
        }

        public static List<Student> GetAllStudent()
        {
            return AllStudent;
        }

        public static Student GetAStudent(string email)
        {
            return AllStudent.FirstOrDefault(x => x.Email == email);
        }

        public static Student UpdateStudent(string email, Student department)
        {
            Student result = new Student();
            foreach (var aStudent in AllStudent)
            {
                if(email == aStudent.Email)
                {
                    aStudent.Name = department.Name;
                    result = aStudent;
                }
            }

            return result;
        }

        public static Student DeleteStudent(string emami)
        {
            var department = AllStudent.FirstOrDefault(x => x.Email == emami);
            AllStudent = AllStudent.Where(x => x.Email != department.Email).ToList();
            return department;
        }
    }
}