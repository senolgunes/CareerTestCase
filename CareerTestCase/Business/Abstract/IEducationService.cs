using CareerTestCase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerTestCase.Business.Abstract
{
    public interface IEducationService
    {
        Task<bool> AddAsync(EducationDTO entity);
        Task<IEnumerable<EducationDTO>> GetByUserIdAsync(int userId);
    }
}
