using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach
{
    class Pravit:Architect
    {
        public string _countryName { get; }

        public Pravit(string name, string ctryName)
        {
            Name = name;
            _countryName = ctryName;
        } 
    }
}
