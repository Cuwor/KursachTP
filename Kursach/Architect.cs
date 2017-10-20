using System;
using System.Collections;
using System.Collections.Generic;

namespace Kursach
{


    internal class Architect : IComparable
    {
        public string Name { get; set; }
        public int CompareTo(object obj)
        {
            Architect other = (Architect) obj;
            return String.Compare(Name, other.Name, StringComparison.Ordinal);
        }
    }
}