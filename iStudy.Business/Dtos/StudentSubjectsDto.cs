using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iStudy.Business.Dtos
{
    public class StudentSubjectsDto
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }

        public bool Mark { get; set; }
    }
}
