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

        public IEnumerable<CatVotes> GetByVotes()
        {
            List<CatVotes> catsVotes = JsonHelper.GetJson<DataCatVotes>("catsVotes").Votes;
            if (catsVotes.Count == 0)
                return null;
            return catsVotes.OrderByDescending(x => x.NumberVote);
        }

        public Cat GetCat(string id) => GetAll().FirstOrDefault(x => x.Id == id);

        public void AddVote(string id)
        {
            Cat currentCat = GetCat(id);
            if (currentCat == null)
                throw new Exception("Unknow Cat Id");


            List<CatVotes> catsVotes = JsonHelper.GetJson<DataCatVotes>("catsVotes").Votes;
            CatVotes currentCatVotes = catsVotes.FirstOrDefault(x => x.CatId == id);
            if (currentCatVotes == null)
            {
                currentCatVotes = new CatVotes();
                currentCatVotes.CatId = id;
            } else {
                catsVotes.Remove(currentCatVotes);
            }
            currentCatVotes.NumberVote++;
            catsVotes.Add(currentCatVotes);
            DataCatVotes datasToStore = new DataCatVotes() { Votes = catsVotes };
            JsonHelper.WriteInDatabase<DataCatVotes>(datasToStore, "catsVotes");
        }
    }
}
