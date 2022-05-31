using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracted.Repositories;

namespace Contracted.Services
{
    public class JobsService
    {
        private readonly JobsRepository _repo;

        public JobsService(JobsRepository repo)
        {
            _repo = repo;
        }
    }
}