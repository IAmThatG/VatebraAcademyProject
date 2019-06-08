using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELearningApi.CustomFilters;
using ElearningApp.Data;
using ElearningApp.Data.Entities;
using ElearningApp.Data.Repository.Interfaces;
using ELearnngApp.Domain.ApiRequestModels;
using ELearnngApp.Domain.ApiResponseModels;
using ELearnngApp.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        [ModelValidation]
        [Authorize]
        public async Task<IActionResult> GetStudentByMatricNumber(string matricNumber)
        {
            var claims = this.User.Claims;
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
        [ModelValidation]
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

        [HttpPut("{matricNo}")]
        [ModelValidation]
        public async Task<IActionResult> EditStudent([FromBody] StudentRequest studentRequest, string matricNo)
        {
            StudentResponse studentResponse;
            try
            {
                //check if student exist
                var studentToUpdate = await _studentService.GetByMatricNumberAsync(matricNo);
                if (studentToUpdate == null)
                {
                    return NotFound("Sorry, student doesn't exist");
                }

                studentResponse = await _studentService.Update(studentRequest, matricNo);
                if (studentResponse == null)
                {
                    return BadRequest("Failed to update student");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured while serving this request", ex);
                return StatusCode(500, "A system error occured");
            }
            return Ok(studentResponse);
        }

        [HttpDelete("{matricNumber}")]
        public async Task<IActionResult> DeleteStudent(string matricNumber)
        {
            try
            {
                bool isDeleted = await _studentService.Delete(matricNumber);
                if (!isDeleted)
                {
                    return BadRequest("Failed to delete student");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Internal server error occured while deleting student", ex);
                return StatusCode(500, "internal server error");
            }
            return Ok("Student Deletes Successfully");
        }
    }
}
