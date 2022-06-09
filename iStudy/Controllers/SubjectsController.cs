using iStudy.Business.Dtos;
using iStudy.Business.Services;
using iStudy.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace iStudy.API.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class SubjectsController : Controller
    {
        private readonly ISubjectService _subjectsService;

        public SubjectsController(

            ISubjectService subjectService
            )
        {
            this._subjectsService = subjectService;
        }

        [HttpGet("GET-ALL-SUBJECTS")]
        public IEnumerable<SUBJECTS> Get()
        {
            var teachers = _subjectsService.GetAll();
            return teachers;
        }
        [HttpPost("CREATE-SUBJECTS")]
        public IActionResult Create(SubjectsDto subjects)
        {

            var result = _subjectsService.CreateSubjects(subjects);

            if (result != null)
            {
                return Ok(result);
            }
            else return BadRequest(result);

        }

        [HttpPatch("UPDATE-SUBJECTS")]
        public IActionResult UpdateSubjects(int subjects)
        {
            var result = _subjectsService.Delete(subjects).Result;

            if (result)
            {
                return Ok("Succes");
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpDelete("DELETE-SUBJECTS")]
        public IActionResult DeleteSubjects(int id)
        {
            var result = _subjectsService.Delete(id).Result;

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
