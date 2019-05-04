using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElearningApp.Data.Entities;
using ElearningApp.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ElearningApp.Data.Repository
{
    public class StudentRepo : IStudentRepository
    {
        private readonly ELearningDataContext _dataContext;
        private readonly ILogger _logger;

        public StudentRepo(ELearningDataContext dataContext, ILogger<StudentRepo> logger)
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        public async Task<Student> Insert(Student obj)
        {
            var createdStudent = await _dataContext.Students.AddAsync(obj);
            var changeCount = _dataContext.SaveChangesAsync();
            if (changeCount.Result > 0)
            {
                //do something
                _logger.LogDebug("Data inserted successfully");
            }
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

        public async Task<Student> SelectByMatricNumberAsync(string matricNumber)
        {
            var student = await _dataContext.Students.Include(s => s.Enrolments)
                .SingleOrDefaultAsync(s => s.MaticNumber.Equals(matricNumber));
            return student;
        }
    }
}
