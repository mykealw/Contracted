using System;
using System.Collections.Generic;
using Contracted.Models;
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

        internal List<CompaniesContractorContractorViewModel> GetJobs(int companyId)
        {
            List<CompaniesContractorContractorViewModel> jobs = _repo.GetJobs(companyId);
            return jobs;
        }

        internal Job Create(Job job)
        {
            Job newJob = _repo.Create(job);
            return newJob;
        }

        internal void Delete(int id)
        {
            Job foundJob = Get(id);
            _repo.Delete(id);
        }

        private Job Get(int id)
        {
            Job foundJob = _repo.Get(id);
            if (foundJob == null)
            {
                throw new Exception("invalid ID");
            }
            return foundJob;
        }
    }
}