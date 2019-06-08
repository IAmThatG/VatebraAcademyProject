using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElearningApp.Data.Entities;

namespace ELearnngApp.Domain.Services.Interfaces
{
    // T is the return type of the method
    // G is the parameter type of the method
    public interface IService<T, G> 
    {
        IList<T> GetAll();
        Task<T> GetByIdAsync(long id);
        Task<T> Create(G obj);
        Task<T> Update(G obj, string uniqueIdentifier);
        Task<bool> Delete(string uniqueIdentifier);
    }
}
