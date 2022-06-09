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
    public class CitiesController : Controller
    {
        private readonly ICitiesService _citiesService;
        public CitiesController(ICitiesService citiesService)
            
        {
            this._citiesService = citiesService;
        }
      

        [HttpGet("GET-ALL-CITIES")]
        public IEnumerable<CITIES> Get()
        {
            var cities = _citiesService.GetAll();
            return cities;
        }

        [HttpPost("CREATE-CITY")]
        public Task<CITIES> CreateCities(CitiesDto cities)
        {
            return _citiesService.CreateCities(cities);
        }


        [HttpPost("UPDATE-CITY")]
        public  IActionResult UpdateCities(CitiesDto cities)
        {
            var result = _citiesService.UpdateCites(cities).Result;

            if(result)
            {
                return Ok("Succes");
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPost("DELETE-CITY")]
        public IActionResult DeleteCities(int id)
        {
            var result = _citiesService.Delete(id).Result;

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
