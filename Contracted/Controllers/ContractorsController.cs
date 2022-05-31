using System;
using System.Collections.Generic;
using Contracted.Models;
using Contracted.Services;
using Microsoft.AspNetCore.Mvc;

namespace Contracted.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ContractorsController : ControllerBase
    {
        private readonly ContractorsService _cs;

        public ContractorsController(ContractorsService cs)
        {
            _cs = cs;
        }

        [HttpGet]
        public ActionResult<List<Contractor>> Get()
        {
            try
            {
                List<Contractor> contractors = _cs.Get();
                return Ok(contractors);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Contractor> Get(int id)
        {
            try
            {
                Contractor contractor = _cs.Get(id);
                return Ok(contractor);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Contractor> Create([FromBody] Contractor contractor)
        {
            try
            {
                Contractor newContractor = _cs.Create(contractor);
                return Ok(newContractor);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Contractor> Edit([FromBody] Contractor contractor, int id)
        {
            try
            {
                contractor.Id = id;
                Contractor editContractor = _cs.Edit(contractor);
                return Ok(editContractor);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Contractor> Delete(int id)
        {
            try
            {
                _cs.Delete(id);
                return Ok("DELETED");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}