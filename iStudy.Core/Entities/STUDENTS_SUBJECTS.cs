using iStudy.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iStudy.Core.Entities
{
    public class STUDENTS_SUBJECTS : Entity
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }

        public bool Mark { get; set; }

        public SUBJECTS SUBJECTS { get; set; }

        public STUDENTS STUDENTS { get; set; }
        
    }
}
