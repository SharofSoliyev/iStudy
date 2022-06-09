using iStudy.Business.Dtos;
using iStudy.Business.Services;
using iStudy.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iStudy.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeacherSubjectsController : Controller
    {
        private readonly ITeacherSubjectsService _teacherSubjectsService;

        public TeacherSubjectsController(ITeacherSubjectsService teacherSubjectsService)
        {
            this._teacherSubjectsService = teacherSubjectsService;
        }

        [HttpGet("GET-ALL-TEACHER-SUBJECTS")]
        public IEnumerable<TEACHERS_SUBJECTS> Get()
        {
            var teachersubjects = _teacherSubjectsService.GetAll();
            return teachersubjects;
        }

        [HttpPost("CREATE-TEACHER-SUBJECTS")]
        public Task<TEACHERS_SUBJECTS> CreateCities(TeachersSubjectsDto teachersSubjectsDto)
        {
            return _teacherSubjectsService.CreateTeachersSubject(teachersSubjectsDto);
        }


        [HttpPatch("UPDATE-TEACHER-SUBJECTS")]
        public IActionResult UpdateStudentSubjects(TeachersSubjectsDto teachersSubjectsDto)
        {
            var result = _teacherSubjectsService.UpdateTeacherSubject(teachersSubjectsDto).Result;

            if (result)
            {
                return Ok("Succes");
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpDelete("DELETE-TEACHER-SUBJECTS")]
        public IActionResult DeleteStudentSubjects(int id)
        {
            var result = _teacherSubjectsService.Delete(id).Result;

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
