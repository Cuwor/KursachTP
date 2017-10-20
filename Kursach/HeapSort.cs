using System;

namespace Kursach
{
    public class Heap<T> where T : IComparable
    {
        private readonly T[] _array; //массив сортируемых элементов
        private int heapsize; //число необработанных элементов

        public Heap(T[] a)
        {
            _array = a;
            heapsize = a.Length;
        }


        public void HeapSort()
        {
            build_max_heap(); //Построение пирамиды
            for (var i = _array.Length - 1; i > 0; i--)
            {
                var temp = _array[0]; //Переместим текущий максимальный элемент из нулевой позиции в хвост массива
                _array[0] = _array[i];
                _array[i] = temp;

                heapsize--; //Уменьшим число необработанных элементов
                max_heapify(0); //Восстановление свойства пирамиды
            }
        }

        private int Parent(int i)
        {
            return (i - 1) / 2;
        } //Индекс родительского узла

        private int left(int i)
        {
            return 2 * i + 1;
        } //Индекс левого потомка

        private int right(int i)
        {
            return 2 * i + 2;
        } //Индекс правого потомка

        //Метод переупорядочивает элементы пирамиды при условии,
        //что элемент с индексом i меньше хотя бы одного из своих потомков, нарушая тем самым свойство невозрастающей пирамиды
        private void max_heapify(int i)
        {
            var l = left(i);
            var r = right(i);
            var lagest = i;
            if (l < heapsize && _array[l].CompareTo(_array[i]) > 0)
                lagest = l;
            if (r < heapsize && _array[r].CompareTo(_array[lagest]) > 0)
                lagest = r;
            if (lagest != i)
            {
                var temp = _array[i];
                _array[i] = _array[lagest];
                _array[lagest] = temp;

                max_heapify(lagest);
            }
        }

        //метод строит невозрастающую пирамиду
        private void build_max_heap()
        {
            var i = (_array.Length - 1) / 2;

            while (i >= 0)
            {
                max_heapify(i);
                i--;
            }
        }
    }
}