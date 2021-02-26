using CareerTestCase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerTestCase.Business.Abstract
{
    public interface ICVService
    {
        Task<bool> AddAsync(CvDTO entity);
        Task<CvDTO> GetByUserIdAsync(int userId);
        //Task<CvDetail> GetCVDetailByUserIdAsync(int userId);
    }
}
