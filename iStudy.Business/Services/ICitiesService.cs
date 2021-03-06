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
    public interface ICitiesService
    {

        public IEnumerable<CITIES> GetAll();

        public Task<CITIES> CreateCities(CitiesDto studentSubjectsDto);
        public Task<bool> UpdateCites(CitiesDto studentSubjectsDto);

        public Task<bool> Delete(int id);
    }

    public class CitiesService : ICitiesService
    {

        public readonly IRepository<CITIES> _repository;
        public readonly IMapper _mapper;
        public CitiesService(
              IRepository<CITIES> repository,
            IMapper mapper
            )
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public Task<CITIES> CreateCities(CitiesDto cities)
        {
            var result = _mapper.Map<CITIES>(cities);
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

        public IEnumerable<CITIES> GetAll()
        {
            var result = _repository.GetAll().ToList();
            return result;
        }

        public async Task<bool> UpdateCites(CitiesDto cities)
        {
            try
            {
                var result = _mapper.Map<CITIES>(cities);
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
