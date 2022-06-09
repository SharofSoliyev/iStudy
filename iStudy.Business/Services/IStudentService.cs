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
    public class StudentService : IStudentService
    {
        public readonly IRepository<STUDENTS> _repository;
        public readonly IMapper _mapper;

        public StudentService(
             IRepository<STUDENTS> repository,
            IMapper mapper
            )
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        public Task<STUDENTS> CreateStudents(StudentDto st)
        {
            var result = _mapper.Map<STUDENTS>(st);
            return _repository.AddAsync(result);
        }
        
        public async Task<bool> DeleteStudents(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            if (result == null)
                return false;
            else { await _repository.DeleteAsync(result); return true; }
        }
        

        public List<STUDENTS> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public STUDENTS GetById(int id)
        {
            var result = _repository.GetAllByExp(s => s.Id == id).FirstOrDefault();

            return result;
        }

        public List<STUDENTS> GetByOrderAge()
        {
            var result =   _repository.GetAll().OrderBy(s => s.Age).ToList();
            return result;
        }

        public List<STUDENTS> GetByOrderCity()
        {
            var result = _repository.GetAll().OrderBy(s => s.CityId).ToList();
            return result;
        }

        public List<STUDENTS> GetByOrderDepartment()
        {
            var result = _repository.GetAll().OrderBy(s => s.DepartmentId).ToList();
            return result;
        }

        public List<STUDENTS> GetByOrderGender()
        {
            var result = _repository.GetAll().OrderBy(s => s.Gender).ToList();
            return result;
        }

        public List<STUDENTS> GetByOrderGrade()
        {
            var result = _repository.GetAll().OrderBy(s => s.CurrentGradeLevel).ToList();
            return result;
        }

        public List<STUDENTS> GetByOrderStudyingSubject()
        {

            throw new Exception();
        }

        public List<STUDENTS> GetByOrderZodiacSign()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateStudents(StudentDto st)
        {
            try
            {
                var result = _mapper.Map<STUDENTS>(st);
               await _repository.UpdateAsync(result);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

    
    }
    public interface IStudentService
    {
        public List<STUDENTS> GetAll();
        public STUDENTS GetById(int id);
        public List<STUDENTS> GetByOrderGender();

        public Task<STUDENTS> CreateStudents(StudentDto st);
        public Task<bool> UpdateStudents(StudentDto st);
        public Task<bool> DeleteStudents(int st);

        public List<STUDENTS> GetByOrderDepartment();
        public List<STUDENTS> GetByOrderAge();
        public List<STUDENTS> GetByOrderCity();

        public List<STUDENTS> GetByOrderZodiacSign();

        public List<STUDENTS> GetByOrderGrade();

        public List<STUDENTS> GetByOrderStudyingSubject();

    }
}
