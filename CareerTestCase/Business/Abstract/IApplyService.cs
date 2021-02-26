using CareerTestCase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerTestCase.Business.Abstract
{
    public interface IApplyService
    {
        Task<bool> AddAsync(ApplyDTO entity);
        Task<IEnumerable<ApplyDTO>> GetAppyByJobId(int jobid);
    }
}
