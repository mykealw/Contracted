using System;
using System.Collections.Generic;
using Contracted.Models;
using Contracted.Services;
using Microsoft.AspNetCore.Mvc;

namespace Contracted.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : ControllerBase
    {

        private readonly CompaniesService _cs;
        private readonly JobsService _js;

        public CompaniesController(CompaniesService cs, JobsService js)
        {
            _cs = cs;
            _js = js;
        }

        [HttpGet]
        public ActionResult<List<Company>> Get()
        {
            try
            {
                List<Company> companies = _cs.Get();
                return Ok(companies);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Company> Get(int id)
        {
            try
            {
                Company company = _cs.Get(id);
                return Ok(company);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/jobs")]
        public ActionResult<List<CompaniesContractorContractorViewModel>> GetJobs(int id)
        {
            try
            {
                List<CompaniesContractorContractorViewModel> jobs = _js.GetJobs(id);
                return Ok(jobs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Company> Create([FromBody] Company company)
        {
            try
            {
                Company newCompany = _cs.Create(company);
                return Ok(newCompany);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Company> Edit([FromBody] Company company, int id)
        {
            try
            {
                company.Id = id;
                Company editCompany = _cs.Edit(company);
                return Ok(editCompany);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Company> Delete(int id)
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