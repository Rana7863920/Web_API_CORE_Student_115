﻿namespace WebApplication_StudentAPI_115.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IStudentRepository Student { get; }
        IEmployeeRepository Employee { get; }
        IUserRepository User { get; }
        int Save();
    }
}
