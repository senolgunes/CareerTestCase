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
    public class ExperinceService : IExperinceService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Experince> _repository;
        public ExperinceService(IMapper mapper, IUnitOfWork unit)
        {
            _repository = unit.GetRepository<Experince>();
            _mapper = mapper;
        }
        public async Task<bool> AddAsync(ExperinceDTO entity)
        {
            var experince = _mapper.Map<Experince>(entity);
            return await _repository.AddAsync(experince);
        }

        public async Task<IEnumerable<ExperinceDTO>> GetByUserIdAsync(int userId)
        {
            var exp = await _repository.GetAllAsync(t => t.UserId == userId);
            return _mapper.Map<IEnumerable<ExperinceDTO>>(exp);
        }

        public async Task<string> GetTotalExperience(int userid)
        {
            var exp = await _repository.GetAllAsync(t => t.UserId == userid);
            var experinces = _mapper.Map<IEnumerable<ExperinceDTO>>(exp);
            int days = 0;
            foreach (var item in experinces)
            {
                days += (item.EndDate - item.StartDate).Value.Days;
            }
            int year = days / 365;
            int month = (days - (year * 365)) / 30;
            return $"Total experince is  {year} year and {month} months.";
        }
    }
}
