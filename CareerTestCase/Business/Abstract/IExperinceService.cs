using CareerTestCase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerTestCase.Business.Abstract
{
    public interface IExperinceService
    {
        Task<bool> AddAsync(ExperinceDTO entity);
        Task<IEnumerable<ExperinceDTO>> GetByUserIdAsync(int userId);
        Task<string> GetTotalExperience(int userid);
    }
}
