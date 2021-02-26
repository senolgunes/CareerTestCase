using AutoMapper;
using CareerTestCase.Business.Abstract;
using CareerTestCase.DAL.Entities;
using CareerTestCase.DAL.Repository;
using CareerTestCase.DAL.UnitOfWork;
using CareerTestCase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerTestCase.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<User> _repository;
        public UserService(IUnitOfWork unit, IMapper mapper )
        {
            _mapper = mapper;
            _repository = unit.GetRepository<User>();
        }
        public async  Task<bool> AddAsync(UserDTO entity)
        {
           var user= _repository.Get(t => t.Email == entity.Email);
            if (user!=null)
                return false;
           var u = _mapper.Map<User>(entity);
           return  await _repository.AddAsync(u);
        }

        public async Task<UserDTO> GetByIdAsync(int userId)
        {
            var user=await _repository.GetByIdAsync(userId);
            return    _mapper.Map<UserDTO>(user);   
        }
    }
}
