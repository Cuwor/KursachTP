using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach
{
    class Grajdan:Architect
    {
        private readonly float _height1;

        public float _height
        {
            get { return _height1; }
        }

        public Grajdan(string height, string name)
        {
            Name = name;
            float.TryParse(height, out _height1);
        }
    }
}
