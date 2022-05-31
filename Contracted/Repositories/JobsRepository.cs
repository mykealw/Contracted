using System.Collections.Generic;
using System.Data;
using System.Linq;
using Contracted.Models;
using Dapper;

namespace Contracted.Repositories
{
    public class JobsRepository
    {
        private readonly IDbConnection _db;

        public JobsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<CompaniesContractorContractorViewModel> GetJobs(int companyId)
        {
            string sql = @"
            SELECT 
            cont.*,
            j.id AS jobsId
            FROM jobs j
            JOIN contractors cont ON j.contractorId = cont.id
            WHERE j.companyId = @companyId;";
            return _db.Query<CompaniesContractorContractorViewModel>(sql, new { companyId }).ToList();
        }

        internal Job Create(Job job)
        {
            string sql = @"
            INSERT INTO jobs
            (companyId, contractorId)
            VALUES
            (@CompanyId, ContractorId);
            SELECT LAST_INSERT_ID;";
            job.Id = _db.ExecuteScalar<int>(sql, job);
            return job;
        }

        internal Job Get(int id)
        {
            string sql = "SELECT * FROM jobs WHERE id = @id;";
            return _db.QueryFirstOrDefault<Job>(sql, new { id });
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM jobs WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
        }
    }
}