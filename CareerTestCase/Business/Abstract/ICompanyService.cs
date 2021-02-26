using CareerTestCase.Business.Services;
using CareerTestCase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerTestCase.Business.Abstract
{
    public interface ICompanyService
    {
        Task<bool> AddAsync(CompanyDTO entity);
        Task<CompanyDTO> GetByIdAsync(int id);
    }
}
