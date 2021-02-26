using AutoMapper;
using CareerTestCase.Business.Abstract;
using CareerTestCase.Business.Services;
using CareerTestCase.DAL.Entities;
using CareerTestCase.DAL.UnitOfWork;
using CareerTestCase.Model;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerTestCase.Configuration
{
    public class AppConfiguration
    {

        public static IMapper ConfigureMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDTO, User>()
                    .ForMember(x => x.Id, opt => opt.Ignore());
                cfg.CreateMap<User, UserDTO>();

                cfg.CreateMap<JobDTO, Job>()
                  .ForMember(x => x.Id, opt => opt.Ignore());
                cfg.CreateMap<Job, JobDTO>();

                cfg.CreateMap<ExperinceDTO, Experince>()
              .ForMember(x => x.Id, opt => opt.Ignore());
                cfg.CreateMap<Experince, ExperinceDTO>();

                cfg.CreateMap<CvDTO, Cv>();
                cfg.CreateMap<Cv, CvDTO>();

                cfg.CreateMap<EducationDTO, Education>()
             .ForMember(x => x.Id, opt => opt.Ignore());
                cfg.CreateMap<Education, EducationDTO>();

                cfg.CreateMap<CompanyDTO, Company>()
               .ForMember(x => x.Id, opt => opt.Ignore());
                cfg.CreateMap<Company, CompanyDTO>();

                cfg.CreateMap<ApplyDTO, Apply>()
            .ForMember(x => x.Id, opt => opt.Ignore());
                cfg.CreateMap<Apply, ApplyDTO>();
            });
            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}
