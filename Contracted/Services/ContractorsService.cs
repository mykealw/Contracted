using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracted.Repositories;

namespace Contracted.Services
{
    public class ContractorsService
    {
        private readonly ContractorsRepository _repo;

        public ContractorsService(ContractorsRepository repo)
        {
            _repo = repo;
        }
    }
}