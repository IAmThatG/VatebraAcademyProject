using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElearningApp.Data.Repository.Interfaces
{
    public interface IRepository<T>
    {
        IList<T> SelectAll();
        Task<T> SelectByIdAsync(long id);
        Task<T> Insert(T obj);
        Task<T> Update(T obj);
        Task<int> Delete(T obj);
    }
}
