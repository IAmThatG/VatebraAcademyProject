using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ElearningApp.Data.Entities;
using ElearningApp.Data.Repository.Interfaces;
using ELearnngApp.Domain.ApiRequestModels;
using ELearnngApp.Domain.ApiResponseModels;
using ELearnngApp.Domain.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace ELearnngApp.Domain.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<StudentService> _logger;

        public StudentService(IStudentRepository studentRepo, IMapper mapper,
            ILogger<StudentService> logger)
        {
            _mapper = mapper;
            _logger = logger;
            _studentRepo = studentRepo;
        }

        public async Task<StudentResponse> Create(StudentRequest obj)
        {
            _logger.LogInformation("Attempting to create student in service");
            var student = _mapper.Map<Student>(obj);
            var createdStudent = await _studentRepo.Insert(student);
            var studentResponse = _mapper.Map<StudentResponse>(createdStudent);
            return studentResponse;
        }

        public async Task<bool> Delete(string matricNumber)
        {
            //retrieve student by matric
            var studentToDelete = await _studentRepo.SelectByMatricNumberAsync(matricNumber);
            //tell repo to delete student
            int affectedRows = await _studentRepo.Delete(studentToDelete);
            return affectedRows > 0 ? true : false;
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

        public async Task<StudentResponse> GetByMatricNumberAsync(string matricNumber)
        {
            var student = await _studentRepo.SelectByMatricNumberAsync(matricNumber);
            var studentResponse = _mapper.Map<StudentResponse>(student);
            return studentResponse;
        }

        public async Task<StudentResponse> Update(StudentRequest obj, string matricNumber)
        {
            var student = await _studentRepo.SelectByMatricNumberAsync(matricNumber);
            var studentUpdate = _mapper.Map(obj, student);
            studentUpdate.DateUpdated = DateTime.Now;
            var updatedStudent = await _studentRepo.Update(studentUpdate);
            var studentResponse = _mapper.Map<StudentResponse>(updatedStudent);
            return studentResponse;
        }
    }
}
