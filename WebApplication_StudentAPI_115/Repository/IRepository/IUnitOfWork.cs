﻿using System.Data;

namespace WebApplication_StudentAPI_115.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IStudentRepository Student { get; }
        IEmployeeRepository Employee { get; }
        IUserRepository User { get; }
        ISubjectRepository Subject { get; }
        IDepartmentRepository Department { get; }
        ICompanyRepository Company { get; }
        IProductRepository Product { get; }
        IBlogRepository Blog { get; }
        IPostRepository Post { get; }
        IDbTransaction BeginTransaction();
        int Save();
    }
}
