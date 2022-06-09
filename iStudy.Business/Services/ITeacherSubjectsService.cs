using AutoMapper;
using iStudy.Business.Dtos;
using iStudy.Core.Entities;
using iStudy.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iStudy.Business.Services
{
    public interface ITeacherSubjectsService
    {
        public IEnumerable<TEACHERS_SUBJECTS> GetAll();

        public Task<TEACHERS_SUBJECTS> CreateTeachersSubject(TeachersSubjectsDto teachersSubjectsDto);
        public Task<bool> UpdateTeacherSubject(TeachersSubjectsDto teachersSubjectsDto);

        public Task<bool> Delete(int id);
    }

    public class TeacherSubjectsService : ITeacherSubjectsService
    {
        public readonly IRepository<TEACHERS_SUBJECTS> _repository;
        public readonly IMapper _mapper;
        public TeacherSubjectsService(

            IRepository<TEACHERS_SUBJECTS> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            
                
        }
        public Task<TEACHERS_SUBJECTS> CreateTeachersSubject(TeachersSubjectsDto teachersSubjectsDto)
        {
            var teachersSubjects = _mapper.Map<TEACHERS_SUBJECTS>(teachersSubjectsDto);
            return _repository.AddAsync(teachersSubjects);
        }

        public async Task<bool> Delete(int id)
        {

            try
            {
                var teachersSubjects = await _repository.GetByIdAsync(id);

                await _repository.DeleteAsync(teachersSubjects);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public IEnumerable<TEACHERS_SUBJECTS> GetAll()
        {

            var teachersSubjects = _repository.GetAll().ToList();
            return teachersSubjects;
        }

        public async Task<bool> UpdateTeacherSubject(TeachersSubjectsDto teachersSubjectsDto)
        {
            try
            {
                var teachersSubjects = _mapper.Map<TEACHERS_SUBJECTS>(teachersSubjectsDto);
                await _repository.UpdateAsync(teachersSubjects);
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
