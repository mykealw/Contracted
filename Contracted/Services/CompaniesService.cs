using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracted.Repositories;

namespace Contracted.Services
{
    public class CompaniesService
    {
        private readonly CompaniesRepository _repo;

        public CompaniesService(CompaniesRepository repo)
        {
            _repo = repo;
        }
    }
}