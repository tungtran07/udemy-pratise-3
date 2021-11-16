﻿using BLL.Request;
using BLL.Services;
using DLL;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    public static class BllDependency
    {
        public static void AllDependency(IServiceCollection services, IConfiguration configuration)
        {
           
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IStudentService, StudentService>();

            AllFluentValidationDependency(services);
        }

        private static void AllFluentValidationDependency(IServiceCollection services)
        {
            services.AddTransient<IValidator<DepartmentInsertRequestViewModel>, DepartmentInsertRequestViewModelValidator>();
        }
    }
}