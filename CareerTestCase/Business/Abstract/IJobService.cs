using CareerTestCase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerTestCase.Business.Abstract
{
    public interface IJobService
    {

        Task<bool> AddAsync(JobDTO entity);
        Task<IEnumerable<JobDTO>> GetByCompanyIdAsync(int userId);
        Task<JobDTO> GetByIdAsync(int id);
    }
}
