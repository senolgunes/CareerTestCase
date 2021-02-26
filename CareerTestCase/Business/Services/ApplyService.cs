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
    public class ApplyService : IApplyService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Apply> repository;
        public ApplyService(IUnitOfWork unit, IMapper mapper, IJobService jobManager)
        {
            _mapper = mapper;
            repository = unit.GetRepository<Apply>();
        }
        public async Task<bool> AddAsync(ApplyDTO entity)
        {
            var apply = _mapper.Map<Apply>(entity);
            return await repository.AddAsync(apply);
        }
        public async Task<IEnumerable<ApplyDTO>> GetAppyByJobId(int jobid)
        {
            var applies = await repository.GetAllAsync(t => t.JopId == jobid);
            return _mapper.Map<IEnumerable<ApplyDTO>>(applies);
        }
    }
}
