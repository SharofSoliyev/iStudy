using iStudy.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iStudy.Business.Services
{
    public interface ICitiesService
    {

        public Task<CITIES> Create();
    }

    public class CitiesService
    {
        public CitiesService()
        {
                
        }
    }
        
}
