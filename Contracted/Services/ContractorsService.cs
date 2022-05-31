using System;
using System.Collections.Generic;
using Contracted.Models;
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

        internal List<Contractor> Get()
        {
            return _repo.Get();
        }

        internal Contractor Get(int id)
        {
            Contractor foundContractor = _repo.Get(id);
            if (foundContractor == null)
            {
                throw new Exception("Invalid Id");
            }
            return foundContractor;
        }

        internal Contractor Create(Contractor contractor)
        {
            Contractor newContractor = _repo.Create(contractor);
            return newContractor;
        }

        internal Contractor Edit(Contractor contractor)
        {
            Contractor original = Get(contractor.Id);
            original.Name = contractor.Name ?? original.Name;
            original.Rate = contractor.Rate != 0 ? contractor.Rate : original.Rate;
            _repo.Edit(original);
            return original;
        }

        internal void Delete(int id)
        {
            Contractor foundContractor = Get(id);
            _repo.Delete(id);
        }
    }
}