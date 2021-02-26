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
    public class EducationService : IEducationService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Education> _repository;
        public EducationService(IUnitOfWork unit, IMapper mapper)
        {
            _mapper = mapper;
            _repository = unit.GetRepository<Education>();
        }
        public async Task<bool> AddAsync(EducationDTO entity)
        {
            var edu = _mapper.Map<Education>(entity);
            return await _repository.AddAsync(edu);
        }
        public async Task<IEnumerable<EducationDTO>> GetByUserIdAsync(int userId)
        {
            var edu = await _repository.GetAllAsync(t => t.UserId == userId);
            return _mapper.Map<IEnumerable<EducationDTO>>(edu);
        }
    }
}
