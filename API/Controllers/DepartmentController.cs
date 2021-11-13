using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    
    public class DepartmentController : MainApiController
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(DepartmentStatic.GetAllDepartments());
        }

        [HttpGet(template: "{code}")]
        public IActionResult GetA(string code)
        {
            return Ok(DepartmentStatic.GetADepartment(code));
        }

        [HttpPost]
        public IActionResult Insert(Department department)
        {
            return Ok(DepartmentStatic.InsertDepartment(department));
        }

        [HttpPut("{code}")]
        public IActionResult Update(string code, Department department)
        {
            return Ok(DepartmentStatic.UpdateDepartment(code, department));
        }

        [HttpDelete]
        public IActionResult Delete(string code)
        {
            return Ok(DepartmentStatic.DeleteDepartment(code));
        }
    }
    public static class DepartmentStatic
    {
        public static List<Department> AllDepartments { get; set; } = new List<Department>();

        public static Department InsertDepartment(Department department)
        {
            AllDepartments.Add(department);
            return department;
        }

        public static List<Department> GetAllDepartments()
        {
            return AllDepartments;
        }

        public static Department GetADepartment(string code)
        {
            return AllDepartments.FirstOrDefault(x => x.Code == code);
        }

        public static Department UpdateDepartment(string code, Department department)
        {
            Department result = new Department();
            foreach (var aDepartment in AllDepartments)
            {
                if(code == aDepartment.Code)
                {
                    aDepartment.Name = department.Name;
                    result = aDepartment;
                }
            }

            return result;
        }

        public static Department DeleteDepartment(string code)
        {
            var department = AllDepartments.FirstOrDefault(x => x.Code == code);
            AllDepartments = AllDepartments.Where(x => x.Code != department.Code).ToList();
            return department;
        }
    }
}