using Catmash2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catmash2020.Services
{
    public class CatService
    {
        public List<Cat> GetAll() => JsonHelper.GetJson<DataCat>("cats").Images;

        public List<CatVotes> GetByVotes()
        {
            List<CatVotes> catsVotes = JsonHelper.GetJson<DataCatVotes>("catsVotes").Votes;
            if (catsVotes.Count == 0)
                return null;

            catsVotes.OrderBy(x => x.NumberVote);
            return catsVotes;
        }

        public Cat GetCat(string id) => GetAll().First(x => x.Id == id);
    }
}
