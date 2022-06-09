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
    public class StudentSubjectController : Controller
    {
        private readonly IStudentSubjectsService _studentSubjectsService;
        public StudentSubjectController(IStudentSubjectsService studentSubjectsService)
        {
            this._studentSubjectsService = studentSubjectsService;
        }


        [HttpGet("GET-ALL-STUDENT-SUBJECTS")]
        public IEnumerable<STUDENTS_SUBJECTS> Get()
        {
            var cities = _studentSubjectsService.GetAll();
            return cities;
        }

        [HttpPost("CREATE-STUDENT-SUBJECTS")]
        public Task<STUDENTS_SUBJECTS> CreateCities(StudentSubjectsDto studentSubjectsDto)
        {
            return _studentSubjectsService.CreateStudentsSubject(studentSubjectsDto);
        }


        [HttpPatch("UPDATE-STUDENT-SUBJECTS")]
        public IActionResult UpdateStudentSubjects(StudentSubjectsDto studentSubjectsDto)
        {
            var result = _studentSubjectsService.UpdateStudentsSubject(studentSubjectsDto).Result;

            if (result)
            {
                return Ok("Succes");
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpDelete("DELETE-STUDENT-SUBJECTS")]
        public IActionResult DeleteStudentSubjects(int id)
        {
            var result = _studentSubjectsService.Delete(id).Result;

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
