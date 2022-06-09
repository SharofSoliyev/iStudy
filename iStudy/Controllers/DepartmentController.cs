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
    public class DepartmentController : Controller
    {
      public  IDepartmentService _departmentService;
        public DepartmentController(
            IDepartmentService departmentService
            )
        {
            this._departmentService = departmentService;
        }


        [HttpGet("GET-ALL-DEPARTMENT")]
        public IEnumerable<DEPARTMENTS> Get()
        {
            var cities = _departmentService.GetAll();
            return cities;
        }

        [HttpPost("CREATE-DEPARTMENT")]
        public Task<DEPARTMENTS> CreateCities(DepartmentDto department)
        {
            return _departmentService.CreateDepartment(department);
        }


        [HttpPost("UPDATE-DEPARTMENT")]
        public IActionResult UpdateCities(DepartmentDto department)
        {
            var result = _departmentService.UpdateDepartment(department).Result;

            if (result)
            {
                return Ok("Succes");
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPost("DELETE-DEPARTMENT")]
        public IActionResult DeleteCities(int id)
        {
            var result = _departmentService.Delete(id).Result;

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
