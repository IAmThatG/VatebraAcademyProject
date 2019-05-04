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
using Microsoft.Extensions.Logging;

namespace ELearningApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly ILogger<StudentController> _logger;

        public StudentController(IStudentService studentService,
            ILogger<StudentController> logger) {
            _studentService = studentService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(_studentService.GetAll());
        }

        //[HttpGet("{id}", Name = "GetStudentById")]
        //public async Task<IActionResult> GetStudentById(long id)
        //{
        //    var student = await _studentService.GetByIdAsync(id);
        //    if (student == null)
        //    {
        //        return NotFound($"Student of id {id} cannot be found");
        //    }
        //    return Ok(student);
        //}

        [HttpGet("{matricNumber}", Name = "GetStudentByMatricNumber")]
        public async Task<IActionResult> GetStudentByMatricNumber(string matricNumber)
        {
            StudentResponse student = null;
            try
            {
                student = await _studentService.GetByMatricNumberAsync(matricNumber);
                if (student == null)
                {
                    return NotFound($"Student of matric number {matricNumber} cannot be found");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured in GetStudentByMatricNumber", ex);
                return StatusCode(500);
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> PostStudent([FromBody] StudentRequest studentRequest)
        {
            string uri = null;
            StudentResponse studentResponse = null;
            try
            {
                studentResponse = await _studentService.Create(studentRequest);
                if (studentRequest == null)
                {
                    return BadRequest("Failed to create student, please check request");
                }
                uri = Url.Link("GetStudentByMatricNumber", new { matricNumber = studentResponse.MaticNumber });
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured within the application", ex);
                return StatusCode(500, "A system error occured");
            }
            return Created(uri, studentResponse);
        }
    }
}
