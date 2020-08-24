using System;
using System.Collections.Generic;

namespace Catmash2020
{
    public class Cat
    {
        public string URL{ get; set; }

        public string Id { get; set; }
    }

    public class DataCat
    {
        public List<Cat> Images { get; set; }
    }
}
