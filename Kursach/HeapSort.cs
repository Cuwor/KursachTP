using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach
{
    partial class Program
    {
        
        internal static void Sort<T>(T[] array, int offset, int length, Comparison<T> comparison)
        {
            if (array == null)
                throw new ArgumentNullException("array");
            if (offset < 0 || length < 0)
                throw new ArgumentOutOfRangeException((length < 0 ? "length" : "offset"), "Non-negative number required.");
            if (array.Length - offset < length)
                throw new ArgumentException("Offset and length were out of bounds for the array or count is greater than the number of elements from index to the end of the source collection.");
            if (comparison == null)
                throw new ArgumentNullException("comparison");
            for (var i = 0; i < length; i++)
            {
                var index = i;
                var item = array[offset + i];
                while (index > 0 && comparison(array[offset + (index - 1) / 2], item) < 0)
                {
                    var top = (index - 1) / 2;
                    array[offset + index] = array[offset + top];
                    index = top;
                }
                array[offset + index] = item;
            }
            for (var i = length - 1; i > 0; i--)
            {
                var last = array[offset + i];
                array[offset + i] = array[offset];
                var index = 0;
                while (index * 2 + 1 < i)
                {
                    int left = index * 2 + 1, right = left + 1;
                    if (right < i && comparison(array[offset + left], array[offset + right]) < 0)
                    {
                        if (comparison(last, array[offset + right]) > 0)
                            break;
                        array[offset + index] = array[offset + right];
                        index = right;
                    }
                    else
                    {
                        if (comparison(last, array[offset + left]) > 0)
                            break;
                        array[offset + index] = array[offset + left];
                        index = left;
                    }
                }
                array[offset + index] = last;
            }
        }
    }
}
