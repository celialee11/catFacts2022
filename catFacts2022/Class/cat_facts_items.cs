using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace catFacts2022.Class
{
    public class Facts
    {
        public List<CatFactsList> facts { get; set; }
    }

    public class CatFactsList
    {
        public string fact { get; set; }
        public string length { get; set; }
    }
}