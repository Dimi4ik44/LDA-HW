using System;
using System.Collections.Generic;
using System.Text;

namespace MusicGroup
{
    class Member : IMember
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateJoin { get; set ; }
        public DateTime BirthDate { get; set ; }
        public int Age { get; set; }
        public List<Group> Groups { get; set; }
        public Instrument Instrumentary { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
