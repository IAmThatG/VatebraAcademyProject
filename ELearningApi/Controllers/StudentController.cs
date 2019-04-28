using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElearningApp.Data;
using ElearningApp.Data.Entities;
using ElearningApp.Data.Repository.Interfaces;
using ELearnngApp.Domain.ApiRequestModels;
using ELearnngApp.Domain.ApiResponseModels;
using ELearnngApp.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ELearningApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IService<StudentResponse, StudentRequest> _studentService;

        public StudentController(IService<StudentResponse, StudentRequest> studentService) {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(_studentService.GetAll());
        }

        [HttpGet("{id}", Name = "GetStudentById")]
        public async Task<IActionResult> GetStudentById(long id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound($"Student of id {id} cannot be found");
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> PostStudent([FromBody] StudentRequest studentRequest)
        {
            var studentResponse = await _studentService.Create(studentRequest);
            if(studentRequest == null)
            {
                return BadRequest("Failed to create student, please check request");
            }
            var uri = Url.Link("GetStudentById", new { id = studentResponse.Id });
            return Created(uri, studentResponse);
        }
    }
}
