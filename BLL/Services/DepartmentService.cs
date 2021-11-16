using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Request;
using BLL.Services;
using DLL.Model;
using DLL.Repositories;
using Utility.Exceptions;

public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<List<Department>> GetAllAsync()
        {
            return await _departmentRepository.GetAllAsync();
        }

        public async Task<Department> GetAAsync(string code)
        {
            var department = await _departmentRepository.GetAAsync(code);

            if (department == null)
            {
                throw new ApplicationException(message: "department not found");
            }
            return department;
        }

        public async Task<Department> InsertAsync(DepartmentInsertRequestViewModel request)
        {
            Department aDepartment = new Department();
            aDepartment.Code = request.Code;
            aDepartment.Name = request.Name;
            return await _departmentRepository.InsertAsync(aDepartment);
        }

        public async Task<Department> UpdateAsync(string code, Department adepartment)
        {
            var department = await _departmentRepository.GetAAsync(code);

            if (department == null)
            {
                throw new ApplicationValidationException(message: "department not found");
            }

            if (!string.IsNullOrWhiteSpace(adepartment.Code))
            {
                var existsAlreadyCode = await _departmentRepository.FindByCode(adepartment.Code);
                if (existsAlreadyCode != null)
                {
                    throw new ApplicationException(message: "your updated code already present in uor system");
                }

                department.Code = adepartment.Code;
            }

            if (!string.IsNullOrWhiteSpace(adepartment.Name))
            {
                var existsAlreadyName = await _departmentRepository.FindByName(adepartment.Name);
                if (existsAlreadyName != null)
                {
                    throw new ApplicationException(message: "your updated name already present in uor system");
                }

                department.Name = adepartment.Name;
            }

            if (await _departmentRepository.UpdateAsync(department))
            {
                return department;
            }
            throw new ApplicationException(message: "in update have some problem");
        }

        public async Task<Department> DeleteAsync(string code)
        {
            var department = await _departmentRepository.GetAAsync(code);
            
            if (department == null)
            {
                throw new ApplicationValidationException(message:"department not found");
            }
            if(await _departmentRepository.DeleteAsync(department))
            {
                return department;
            }

            throw new ApplicationValidationException(message:"some problem for delete data");
        }

        public async Task<bool> IsCodeExists(string code)
        {
            var department = await _departmentRepository.FindByCode(code);

            if (department == null)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> IsNameExists(string name)
        {
            var department = await _departmentRepository.FindByName(name);

            if (department == null)
            {
                return true;
            }

            return false;
        }
    }