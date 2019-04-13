using System;
using System.Collections.Generic;
using ElearningApp.Data.Entities;

namespace ELearnngApp.Domain.Services.Interfaces
{
    public interface IService<T>
    {
        IList<T> GetAll();
    }
}
