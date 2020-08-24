using System.Collections.Generic;

namespace Catmash2020.Models
{
    public class CatVotes
    {
        public int NumberVote { get; set; }

        public string CatId { get; set; }
    }

    public class DataCatVotes
    {
        public List<CatVotes> Votes { get; set; }
    }
}
