using AutoMapper;
using iStudy.Business.Dtos;
using iStudy.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iStudy.Business.Mapper
{
    public class IEMapper : Profile
    {
        public IEMapper()
        {

            CreateMap<CitiesDto, CITIES>().ReverseMap();
            CreateMap<DepartmentDto, DEPARTMENTS>().ReverseMap();
            CreateMap<StudentDto, STUDENTS>().ReverseMap();
            CreateMap<StudentSubjectsDto, STUDENTS_SUBJECTS>().ReverseMap();
            CreateMap<SubjectsDto, SUBJECTS>().ReverseMap();
            CreateMap<TeacherDto, TEACHERS>().ReverseMap();
            CreateMap<TeachersSubjects, TEACHERS_SUBJECTS>().ReverseMap();

        }
    }

    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<IEMapper>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;
    }
}
