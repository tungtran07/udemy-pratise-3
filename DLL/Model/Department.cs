using System.ComponentModel.DataAnnotations;

namespace DLL.Model
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}