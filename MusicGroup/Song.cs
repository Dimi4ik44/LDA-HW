using System;
using System.Collections.Generic;
using System.Text;

namespace MusicGroup
{
    class Song
    {
        public string SongName { get; set; }
        public List<Member<Instrument>> MembersPerform { get; set; }
        public Group Group { get; set; }
        public DateTime Release { get; set; }
    }
}
