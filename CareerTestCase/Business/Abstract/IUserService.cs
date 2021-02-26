using CareerTestCase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerTestCase.Business.Abstract
{
    public interface IUserService
    {
        Task<bool> AddAsync(UserDTO entity);
        Task<UserDTO> GetByIdAsync(int userId);
    }
}
