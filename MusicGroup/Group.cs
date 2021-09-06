using System;
using System.Collections.Generic;
using System.Text;

namespace MusicGroup
{
    class Group
    {
        public string Name { get; set; }
        public DateTime LastActivity { get; set; }
        public List<Member<Instrument>> Members { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
