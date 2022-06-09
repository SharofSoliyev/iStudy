using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iStudy.Core.Entities.Base
{
    public abstract class Entity : EntityBase<int>
    {
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}
