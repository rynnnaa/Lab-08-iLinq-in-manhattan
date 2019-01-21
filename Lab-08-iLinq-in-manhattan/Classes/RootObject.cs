using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_08_iLinq_in_manhattan.Classes
{
    public class RootObject
    {
        public string type { get; set; }
        public List<Feature> features { get; set; }
        public IEnumerable<object> Features { get; internal set; }
    }
}
