using System.Collections.Generic;
using System.Threading.Tasks;
using DLL.Model;
using DLL.Repositories;

namespace BLL.Services
{
    public interface IStudentService
    {
        Task<Student> InsertAsync(Student student);

        Task<List<Student>> GetAllAsync();

        Task<Student> UpdateAsync(string email, Student student);

        Task<Student> DeleteAsync(string email);

        Task<Student> GetAAsync(string email);
    }

    
}