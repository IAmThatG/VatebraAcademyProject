using System;
using System.Collections.Generic;

namespace ElearningApp.Data.Repository.Interfaces
{
    public interface IRepository<T>
    {
        IList<T> SelectAll();
    }
}
