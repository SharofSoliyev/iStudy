using iStudy.Business.Dtos;
using iStudy.Business.Services;
using iStudy.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace iStudy.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            this._studentService = studentService;   
        }

     
        [HttpGet("GET-ALL-STUDENTS")]
        public List<STUDENTS> Get()
        {
            var Students = _studentService.GetAll();
            return Students;
        }
        [HttpPost("CREATE-STUDENTS")]
        public IActionResult Create(StudentDto students)
        {
           
              var result =  _studentService.CreateStudents(students);

                if (result != null)
                {
                    return Ok(result);
                }
                else return BadRequest(result);
            
        }

        [HttpPatch("UPDATE-STUDENTS")]
        public IActionResult UpdateStudents(StudentDto students)
        {
            var result = _studentService.UpdateStudents(students).Result;

            if (result)
            {
                return Ok("Succes");
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpDelete("DELETE-STUDENTS")]
        public IActionResult DeleteStudents(int id)
        {
            var result = _studentService.DeleteStudents(id).Result;

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
