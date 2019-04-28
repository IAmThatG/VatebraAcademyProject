using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElearningApp.Data.Entities;
using ElearningApp.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ElearningApp.Data.Repository
{
    public class StudentRepo : IRepository<Student>
    {
        private readonly ELearningDataContext _dataContext;

        public StudentRepo(ELearningDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Student> Insert(Student obj)
        {
            var createdStudent = await _dataContext.Students.AddAsync(obj);
            return createdStudent.Entity;
        }

        public IList<Student> SelectAll()
        {
            var studentQuery = _dataContext.Students.Include(s => s.Enrolments);
            var students = studentQuery.ToList();
            return students;
        }

        public async Task<Student> SelectByIdAsync(long id)
        {
            var student = await _dataContext.Students.Include(s => s.Enrolments)
                                .SingleOrDefaultAsync(s => s.Id == id);
            return student;
        }
    }
}
