using Microsoft.AspNetCore.Mvc;
using BusinessLayer;
using DataLayer;
using System.Collections.Generic;
using System;

namespace Lab7_DotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoisController : ControllerBase
    {
        private readonly IPoiRepository _repository;

        public PoisController(IPoiRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IReadOnlyList<Poi>> Get()
        {
            return Ok(this._repository.GetAll());
        }

        [HttpGet("{id}", Name = "GetById")]
        public ActionResult<Poi> Get(Guid id)
        {
            return Ok(this._repository.Get(id));
        }
        [HttpPost]
        public ActionResult<Poi> Post([FromBody] CreatePoiModel createPoiModel)
        {
            if (createPoiModel == null)
            {
                return BadRequest();
            }

            Poi todo = new Poi(createPoiModel.Name, createPoiModel.Description);
            this._repository.Create(todo);

            return CreatedAtRoute("GetById", new { id = todo.PoiId }, todo);
        }
    }
}