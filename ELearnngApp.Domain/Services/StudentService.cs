﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ElearningApp.Data.Entities;
using ElearningApp.Data.Repository.Interfaces;
using ELearnngApp.Domain.ApiRequestModels;
using ELearnngApp.Domain.ApiResponseModels;
using ELearnngApp.Domain.Services.Interfaces;

namespace ELearnngApp.Domain.Services
{
    public class StudentService : IService<StudentResponse, StudentRequest>
    {
        private readonly IRepository<Student> _studentRepo;
        private readonly IMapper _mapper;

        public StudentService(IRepository<Student> studentRepo, IMapper mapper)
        {
            _mapper = mapper;
            _studentRepo = studentRepo;
        }

        public async Task<StudentResponse> Create(StudentRequest obj)
        {
            var student = _mapper.Map<Student>(obj);
            var createdStudent = await _studentRepo.Insert(student);
            var studentResponse = _mapper.Map<StudentResponse>(createdStudent);
            return studentResponse;
        }

        public IList<StudentResponse> GetAll()
        {
            //IList<StudentResponse> studentsResult = new List<StudentResponse>();
            var students = _studentRepo.SelectAll();
            var studentsResult = _mapper.Map<IList<StudentResponse>>(students);
            //foreach (var student in students)
            //{
            //    studentsResult.Add(new StudentResponse
            //    {
            //        Firstname = student.Firstname,
            //        Lastname = student.Lastname,
            //        MaticNumber = student.MaticNumber,
            //        Enrolments = student.Enrolments
            //    });
            //}
            return studentsResult;
        }

        public async Task<StudentResponse> GetByIdAsync(long id)
        {
            var student = await _studentRepo.SelectByIdAsync(id);
            var studentResponse = _mapper.Map<StudentResponse>(student);
            return studentResponse;
        }
    }
}
