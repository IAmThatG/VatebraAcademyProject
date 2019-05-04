using System;
using System.Threading.Tasks;
using ElearningApp.Data.Entities;
using ElearningApp.Data.Repository;
using ELearnngApp.Domain.ApiRequestModels;
using ELearnngApp.Domain.ApiResponseModels;

namespace ELearnngApp.Domain.Services.Interfaces
{
    public interface IStudentService : IService<StudentResponse, StudentRequest>
    {
        Task<StudentResponse> GetByMatricNumberAsync(string matricNumber);
    }
}
