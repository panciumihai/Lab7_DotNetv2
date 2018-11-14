using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab7_DotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityRepository _repository;

        public CitiesController(ICityRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public ActionResult<IEnumerable<City>> Get()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}", Name = "GetById")]
        public ActionResult<City> Get(Guid id)
        {
            return Ok(_repository.Get(id));
        }

        [HttpPost]
        public ActionResult<City> Post([FromBody] City city)
        {
            if (city == null)
            {
                return BadRequest();
            }

            this._repository.Create(city);

            return CreatedAtRoute("GetById", new { id = city.CityId }, city);
        }

        [Route("{cityId}/pois/{poiId}")]
        public ActionResult<IEnumerable<Poi>> GetPoisByCity(int cityId)
        {
            return Ok();
        }


    }
}