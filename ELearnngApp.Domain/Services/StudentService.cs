using System;
using System.Collections.Generic;
using ElearningApp.Data.Entities;
using ElearningApp.Data.Repository.Interfaces;
using ELearnngApp.Domain.ApiResponseModels;
using ELearnngApp.Domain.Services.Interfaces;

namespace ELearnngApp.Domain.Services
{
    public class StudentService : IService<StudentResponse>
    {
        private readonly IRepository<Student> _studentRepo;

        public StudentService(IRepository<Student> studentRepo)
        {
            _studentRepo = studentRepo;
        }

        public IList<StudentResponse> GetAll()
        {
            IList<StudentResponse> studentsResult = new List<StudentResponse>();
            var students = _studentRepo.SelectAll();
            foreach (var student in students)
            {
                studentsResult.Add(new StudentResponse
                {
                    Firstname = student.Firstname,
                    Lastname = student.Lastname,
                    MaticNumber = student.MaticNumber,
                    Enrolments = student.Enrolments
                });
            }
            return studentsResult;
        }
    }
}
