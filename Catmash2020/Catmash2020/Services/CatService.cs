using Catmash2020.Models;
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

        public List<CatVotes> GetByVotes()
        {
            List<CatVotes> catsVotes = JsonHelper.GetJson<DataCatVotes>("catsVotes").Votes;
            //return cats;
            if (catsVotes.Count == 0)
                return null;

            catsVotes.OrderBy(x => x.NumberVote);
            return catsVotes;
        }
    }
}
