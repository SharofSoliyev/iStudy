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
    public interface ITeachersService
    {
        public List<TEACHERS> GetAll();
        public List<TEACHERS> GetAllSortByGender();

        public List<TEACHERS> GetAllSortByAge();

        public List<TEACHERS> GetAllSortBySubject();

        public Task<TEACHERS> CreateTeachers(TeacherDto st);
        public Task<bool> UpdateTeachers(TeacherDto st);
        public Task<bool> DeleteTeachers(int st);
    }

    public class TeachersService : ITeachersService
    {

        public readonly IRepository<TEACHERS> _repository;
        public readonly IMapper _mapper;

        public TeachersService(IRepository<TEACHERS> repository,IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public Task<TEACHERS> CreateTeachers(TeacherDto st)
        {
            var result = _mapper.Map<TEACHERS>(st);
            return _repository.AddAsync(result);
        }

        public async Task<bool> DeleteTeachers(int id)
        {

            var result = await _repository.GetByIdAsync(id);
            if (result == null)
                return false;
            else { await _repository.DeleteAsync(result); return true; }
        }

        public List<TEACHERS> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public   List<TEACHERS> GetAllSortByAge()
        {

            var result = _repository.GetAllByExp(s => s.Age != 0).OrderBy(s => s.Age).ToList();
            return result;
        }

        public List<TEACHERS> GetAllSortByGender()
        {
            var result = _repository.GetAll().OrderBy(s => s.Gender).ToList();
            return result;
        }

        public List<TEACHERS> GetAllSortBySubject()
        {
              var result = _repository.GetAll().OrderBy(s => s.Gender).ToList();
            return result;
        }

        public  async Task<bool> UpdateTeachers(TeacherDto st)
        {

            try
            {
                var result = _mapper.Map<TEACHERS>(st);
                await _repository.UpdateAsync(result);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
