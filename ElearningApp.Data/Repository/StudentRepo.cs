using System;
using System.Collections.Generic;
using System.Linq;
using ElearningApp.Data.Entities;
using ElearningApp.Data.Repository.Interfaces;

namespace ElearningApp.Data.Repository
{
    public class StudentRepo : IRepository<Student>
    {
        private readonly ELearningDataContext _dataContext;

        public StudentRepo(ELearningDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IList<Student> SelectAll() => _dataContext.Students.ToList();
    }
}
