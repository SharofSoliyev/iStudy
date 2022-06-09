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

        public List<TEACHERS> GetAllSortByGender();

        public List<TEACHERS> GetAllSortByAge();

        public List<TEACHERS> GetAllSortBySubject();
    }

    public class TeachersService : ITeachersService
    {

        public readonly IRepository<TEACHERS> _repository;

        public TeachersService(IRepository<TEACHERS> repository)
        {
            this._repository = repository;
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
    }
}
