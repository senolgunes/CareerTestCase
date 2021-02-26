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
    public class CompanyService : ICompanyService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Company> _repository;
        public CompanyService(IMapper mapper, IUnitOfWork unit)
        {
            _mapper = mapper;
            _repository = unit.GetRepository<Company>();
        }
        public async Task<bool> AddAsync(CompanyDTO entity)
        {
            var res= _repository.Get(t=>t.Name==entity.Name);
            if (res!=null)
                return false;
            var c = _mapper.Map<Company>(entity);
            return await _repository.AddAsync(c);
        }
        public async Task<CompanyDTO> GetByIdAsync(int id)
        {
            var res = await _repository.GetByIdAsync(id);
            return _mapper.Map<CompanyDTO>(res);

        }
    }
}
