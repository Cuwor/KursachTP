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
        public override string ToString()
        {

            return "Правительство: " + _countryName + " а здание зовется - " + Name;
        }

        public Pravit(string name, string ctryName)
        {
            Name = name;
            _countryName = ctryName;
        } 
    }
}
