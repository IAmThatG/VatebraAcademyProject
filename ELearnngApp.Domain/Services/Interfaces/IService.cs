using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElearningApp.Data.Entities;

namespace ELearnngApp.Domain.Services.Interfaces
{
    public interface IService<T, G>
    {
        IList<T> GetAll();
        Task<T> GetByIdAsync(long id);
        Task<T> Create(G obj);
    }
}
