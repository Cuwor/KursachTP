using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach
{
    class Relig:Architect
    {
        private enum _konfess
        {
            Привет,
            Budd,
            Iuda,
            Musul
        }

        public string _relig { get; }

        

        public override string ToString()
        {
            
            return "Религия: "+_relig+", а храм называется "+Name;
        }

        public Relig()
        {
        }

        public Relig(string name, string relig)
        {
            Name = name;
            switch (relig)
            {
                case "Budd":
                    _relig = "Буддизм"; break;
                case "Hrist":
                    _relig = "Христианство"; break;
                case "Iuda":
                    _relig = "Иудаизм"; break;
                case "Musul":
                    _relig = "Мусульманство"; break;
                default: _relig = "Не существует"; break;;
            }
            
        }
    }
}
