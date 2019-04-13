using System;
using System.Collections.Generic;
using System.Linq;
using ElearningApp.Data;
using ElearningApp.Data.Entities;
using ElearningApp.Data.Repository.Interfaces;
using ELearnngApp.Domain.ApiResponseModels;
using ELearnngApp.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ELearningApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IService<StudentResponse> _studentService;

        public StudentController(IService<StudentResponse> studentService) {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(_studentService.GetAll());
        }
    }
}
