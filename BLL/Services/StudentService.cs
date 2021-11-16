using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Services;
using DLL.Model;
using DLL.Repositories;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;


    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    public async Task<Student> InsertAsync(Student student)
    {
        return await _studentRepository.InsertAsync(student);
    }

    public async Task<List<Student>> GetAllAsync()
    {
        return await _studentRepository.GetAllAsync();
    }

    public async Task<Student> UpdateAsync(string email, Student student)
    {
        return await _studentRepository.UpdateAsync(email, student);
    }

    public async Task<Student> DeleteAsync(string email)
    {
        return await _studentRepository.DeleteAsync(email);
    }

    public async Task<Student> GetAAsync(string email)
    {
        return await _studentRepository.GetAAsync(email);
    }
}