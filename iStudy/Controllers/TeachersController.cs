using iStudy.Business.Dtos;
using iStudy.Business.Services;
using iStudy.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace iStudy.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    
    public class TeachersController : Controller
    {
        private readonly ITeachersService _teacherService;
        public TeachersController(ITeachersService teachersService)
        {
            this._teacherService = teachersService;
        }


        [HttpGet("GET-ALL-TEACHERS")]
        public List<TEACHERS> Get()
        {
            var teachers = _teacherService.GetAll();
            return teachers;
        }
        [HttpPost("CREATE-TEACHERS")]
        public IActionResult Create(TeacherDto teacher)
        {

            var result = _teacherService.CreateTeachers(teacher);

            if (result != null)
            {
                return Ok(result);
            }
            else return BadRequest(result);

        }

        [HttpPost("UPDATE-TEACHERS")]
        public IActionResult UpdateStudents(TeacherDto teacher)
        {
            var result = _teacherService.UpdateTeachers(teacher).Result;

            if (result)
            {
                return Ok("Succes");
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPost("DELETE-TEACHERS")]
        public IActionResult DeleteStudents(int id)
        {
            var result = _teacherService.DeleteTeachers(id).Result;

            if (result)
            {
                return Ok("Succes");
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
