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
    public interface ISubjectService
    {
        public IEnumerable<SUBJECTS> GetAll();

        public Task<SUBJECTS> CreateSubjects(SubjectsDto subjectsDto);
        public Task<bool> UpdateSubjects(SubjectsDto subjectsDto);

        public Task<bool> Delete(int id);        
    }

    public class SubjectService : ISubjectService
    {
        private readonly IRepository<SUBJECTS> _repository;
        private readonly IMapper _mapper;
        public SubjectService(
            IRepository<SUBJECTS> repository,
            IMapper mapper
            )
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        public Task<SUBJECTS> CreateSubjects(SubjectsDto subjectsDto)
        {
            var result = _mapper.Map<SUBJECTS>(subjectsDto);
            return _repository.AddAsync(result);
        }

        public async Task<bool> Delete(int id)
        {

            try
            {
                var result = await _repository.GetByIdAsync(id);

                await _repository.DeleteAsync(result);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<SUBJECTS> GetAll()
        {
            var result = _repository.GetAll().ToList();
            return result;
        }

        public async Task<bool> UpdateSubjects(SubjectsDto subjectsDto)
        {

            try
            {
                var result = _mapper.Map<SUBJECTS>(subjectsDto);
                await _repository.UpdateAsync(result);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
