using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catmash2020.Services
{
    public class CatService
    {
        public List<Cat> GetAll()
        {
            List<Cat> cats = JsonHelper.GetJson<DataCat>("cats").Images;
            return cats;
        }
    }
}
