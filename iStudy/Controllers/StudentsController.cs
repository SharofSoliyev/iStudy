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
        public IActionResult Create(STUDENTS students)
        {
           
              var result =  _studentService.CreateStudents(students);

                if (result != null)
                {
                    return Ok(result);
                }
                else return BadRequest(result);
            
        }

        
    }
}
