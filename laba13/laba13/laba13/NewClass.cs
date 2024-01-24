using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace laba13
{
    [DataContract(Name ="Sea", Namespace = "world")]
    class FSea
    {
        public FSea(string name, int? depth)
        {
            Name = name;
            Depth = depth;
        }

        [DataMember(Name = "name")]
        public string Name{ get; set; }
        [DataMember(Name = "depth", Order = 1)]
        public int? Depth { get; set; }
    }
}
