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
    public class JobService : IJobService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Job> _repository;
        public JobService(IUnitOfWork unit, IMapper mapper )
        {
            _mapper = mapper;
            _repository = unit.GetRepository<Job>();
        }
        public async  Task<bool> AddAsync(JobDTO entity)
        {
            var u = _mapper.Map<Job>(entity);
            return await _repository.AddAsync(u);
        }
        public async  Task<IEnumerable<JobDTO>> GetByCompanyIdAsync(int companyId)
        {
            var job = await _repository.GetAllAsync(t => t.CompanyId == companyId);
            return _mapper.Map<IEnumerable<JobDTO>>(job);
        }
        public async  Task<JobDTO> GetByIdAsync(int id)
        {
            var job = await _repository.GetByIdAsync(id);
            return _mapper.Map<JobDTO>(job);
        }
    }
}
