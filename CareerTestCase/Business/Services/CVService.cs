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
    public class CVService : ICVService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Cv> _repository;
        public CVService(IMapper mapper, IUnitOfWork unit)
        {
            _mapper = mapper;
            _repository = unit.GetRepository<Cv>();
        }
        public async Task<bool> AddAsync(CvDTO entity)
        {
            var user = await _repository.GetByIdAsync(entity.UserId);
            if (user != null)
            {
                return false;
            }
            var u = _mapper.Map<Cv>(entity);
            return await _repository.AddAsync(u);
        }
        public async Task<CvDTO> GetByUserIdAsync(int userId)
        {
            var cv = await _repository.GetByIdAsync(userId);
            return _mapper.Map<CvDTO>(cv);
        }
    }
}
