using Microsoft.AspNetCore.Mvc;
using BusinessLayer;
using DataLayer;
using System.Collections.Generic;
using System;

namespace Lab7_DotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoiController : ControllerBase
    {
        private readonly IPoiRepository _repository;

        public PoiController(IPoiRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Poi>> Get()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}", Name = "GetById1")]
        public ActionResult<Poi> Get(Guid id)
        {
            return Ok(_repository.Get(id));
        }

        [HttpPost]
        public ActionResult<Poi> Post([FromBody] Poi poi)
        {
            if (poi == null)
            {
                return BadRequest();
            }

            this._repository.Create(poi);

            return CreatedAtRoute("GetById1", new { id = poi.PoiId }, poi);
        }
    }
}