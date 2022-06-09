using iStudy.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iStudy.Business.Services
{
    public class StudentService : IStudentService
    {
        public Task<STUDENTS> CreateStudents(STUDENTS st)
        {
            throw new NotImplementedException();
        }

        public Task<STUDENTS> DeleteStudents(STUDENTS st)
        {
            throw new NotImplementedException();
        }

        public Task<List<STUDENTS>> GetAll()
        {
            throw new NotImplementedException();
        }

        public STUDENTS GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<STUDENTS>> GetByOrderAge()
        {
            throw new NotImplementedException();
        }

        public Task<List<STUDENTS>> GetByOrderCity()
        {
            throw new NotImplementedException();
        }

        public Task<List<STUDENTS>> GetByOrderDepartment()
        {
            throw new NotImplementedException();
        }

        public Task<List<STUDENTS>> GetByOrderGender()
        {
            throw new NotImplementedException();
        }

        public Task<List<STUDENTS>> GetByOrderGrade()
        {
            throw new NotImplementedException();
        }

        public Task<List<STUDENTS>> GetByOrderStudyingSubject()
        {
            throw new NotImplementedException();
        }

        public Task<List<STUDENTS>> GetByOrderZodiacSign()
        {
            throw new NotImplementedException();
        }

        public Task<STUDENTS> UpdateStudents(STUDENTS st)
        {
            throw new NotImplementedException();
        }
    }
    public interface IStudentService
    {
        public Task<List<STUDENTS>> GetAll();
        public STUDENTS GetById(int id);
        public Task<List<STUDENTS>> GetByOrderGender();

        public Task<STUDENTS> CreateStudents(STUDENTS st);
        public Task<STUDENTS> UpdateStudents(STUDENTS st);
        public Task<STUDENTS> DeleteStudents(STUDENTS st);

        public Task<List<STUDENTS>> GetByOrderDepartment();
        public Task<List<STUDENTS>> GetByOrderAge();
        public Task<List<STUDENTS>> GetByOrderCity();

        public Task<List<STUDENTS>> GetByOrderZodiacSign();

        public Task<List<STUDENTS>> GetByOrderGrade();

        public Task<List<STUDENTS>> GetByOrderStudyingSubject();

    }
}
