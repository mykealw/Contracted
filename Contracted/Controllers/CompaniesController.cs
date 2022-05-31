using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracted.Services;
using Microsoft.AspNetCore.Mvc;

namespace Contracted.Controllers
{
        [ApiController]
        [Route("api/[controller")]
    public class CompaniesController : ControllerBase
    {

private readonly CompaniesService _cs;

        public CompaniesController(CompaniesService cs)
        {
            _cs = cs;
        }
    }
}