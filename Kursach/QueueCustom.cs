using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Kursach
{
    class QueueCustom 
    {
        // Очередь.

        // Узел списка.
        class Node
        {
            public Architect data; // Данные.
            // Ссылка на следующий узел.
            public Node next;
        };

        Node first; // Первый узел списка.
        Node last; // Последний узел списка.
        public void Add(Architect value)
        {
            Node tmp = new Node();
            tmp.data = value;
            tmp.next = null;
            if (first == null)
            {
                first = tmp;
                last = tmp;
            }
            else
            {
                last.next = tmp;
                last = tmp;
            }
        }

        public void Remove()
        {
            if (first != null)
            {
                first = first.next;
                if (first == null)
                    last = null;
            }
        }




        // Вывод содержимого.
        public void Print()
        {
            Write("Содержимое: ");
            Node cur = first;
            while (cur != null)
            {
                Write("{0} ", cur.data);
                cur = cur.next;
            }
            WriteLine();
        }
        // Индексатор.
        public Architect this[int index]
        {
            get
            {
                int g = 0;
                Node currentNode = first;
                while (g < index)
                {
                    if (currentNode != null)
                        currentNode = currentNode.next;
                    g++;
                }
                return currentNode.data;
            }
        }

        public int Count {
            get
            {
                int g = 0;
                Node currentNode = first;
                while (currentNode!= null)
                {
                    currentNode = currentNode.next;
                    g++;
                }
                return g;
            }
        }

        
    }
}

