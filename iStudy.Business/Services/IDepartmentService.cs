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
    public interface IDepartmentService
    {
        public IEnumerable<DEPARTMENTS> GetAll();

        public Task<DEPARTMENTS> CreateDepartment(DepartmentDto studentSubjectsDto);
        public Task<bool> UpdateDepartment(DepartmentDto studentSubjectsDto);

        public Task<bool> Delete(int id);
    }


    public class DepartmentService : IDepartmentService
    {

        public readonly IRepository<DEPARTMENTS> _repository;
        public readonly IMapper _mapper;
        public DepartmentService(
              IRepository<DEPARTMENTS> repository,
            IMapper mapper
            )
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public Task<DEPARTMENTS> CreateDepartment(DepartmentDto departmentDto)
        {
            var result = _mapper.Map<DEPARTMENTS>(departmentDto);
            return _repository.AddAsync(result);
        }

        public  async Task<bool> Delete(int id)
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

        public IEnumerable<DEPARTMENTS> GetAll()
        {
            var result = _repository.GetAll().ToList();
            return result;
        }

        public async Task<bool> UpdateDepartment(DepartmentDto department)
        {

            try
            {
                var result = _mapper.Map<DEPARTMENTS>(department);
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
