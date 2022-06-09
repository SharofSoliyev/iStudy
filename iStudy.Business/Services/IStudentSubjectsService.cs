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
    public interface IStudentSubjectsService
    {
        public IEnumerable<STUDENTS_SUBJECTS> GetAll();

        public Task<STUDENTS_SUBJECTS> CreateStudentsSubject(StudentSubjectsDto studentSubjectsDto);
        public Task<bool> UpdateStudentsSubject(StudentSubjectsDto studentSubjectsDto);

        public Task<bool> Delete(int id);

    }

    public class StudentSubjectsService : IStudentSubjectsService
    {
        public readonly IRepository<STUDENTS_SUBJECTS> _repository;
        public readonly IMapper _mapper;
        
        public StudentSubjectsService(
            IRepository<STUDENTS_SUBJECTS> repository,
            IMapper mapper
            )
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        public Task<STUDENTS_SUBJECTS> CreateStudentsSubject(StudentSubjectsDto studentSubjectsDto)
        {
            var studentSubjects = _mapper.Map<STUDENTS_SUBJECTS>(studentSubjectsDto);
            return _repository.AddAsync(studentSubjects);
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var studentSubjects = await _repository.GetByIdAsync(id);

                await _repository.DeleteAsync(studentSubjects);
                return true;
            }
            catch
            {
                return false;
            }
           
            
        }

        public IEnumerable<STUDENTS_SUBJECTS> GetAll()
        {

            var studentSubjects = _repository.GetAll().ToList();
            return studentSubjects;
        }

        public async Task<bool> UpdateStudentsSubject(StudentSubjectsDto studentSubjectsDto)
        {
            try
            {
                var studentSubjects = _mapper.Map<STUDENTS_SUBJECTS>(studentSubjectsDto);
                await _repository.UpdateAsync(studentSubjects);
                return true;
            }
            catch
            {
                return false;
            }
                        
          
            
        }
    }

}
