using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach
{
    class Relig:Architect
    {
        private enum _konfess
        {
            Hrist,
            Budd,
            Iuda,
            Musul
        }

        public string _relig { get; }

        public Relig()
        {
        }

        public Relig(string name, string relig)
        {
            Name = name;
            _relig = relig;
            //if (relig == _konfess.Hrist.ToString())
            //{
            //    _relig = _konfess.Hrist.ToString();
            //}
        }
    }
}
