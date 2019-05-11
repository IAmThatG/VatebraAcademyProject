using System;
using System.Threading.Tasks;
using ElearningApp.Data.Entities;

namespace ElearningApp.Data.Repository.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<Student> SelectByMatricNumberAsync(string matricNumber);
    }
}
