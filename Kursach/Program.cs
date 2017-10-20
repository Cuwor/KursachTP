using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using static System.Activator;

namespace Kursach
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string outputtext;
            using (var fstream = new FileStream("new.txt", FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                var array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                outputtext = Encoding.Default.GetString(array);
            }


            var qc = new QueueCustom();
            foreach (var fullArray in outputtext.Split('\n'))
                if (fullArray != string.Empty)
                {
                    var a = fullArray.Split(':');
                    var b = a[1].Split(' ');
                    var data =
                        Assembly.LoadFrom("Kursach.exe")
                            .DefinedTypes.ToList()
                            .FindAll(type => type.IsSubclassOf(typeof(Architect))).ToArray();


                    switch (a[0])
                    {
                        case "Религия":
                            var relig = (Relig) CreateInstance(Type.GetType(data[2].FullName), b[1], b[0]);
                            qc.Add(relig);
                            break;
                        case "Правительство":
                            var pravit = (Pravit) CreateInstance(Type.GetType(data[1].FullName), b[1], b[0]);
                            qc.Add(pravit);
                            break;
                        case "Гражданство":
                            var grajdan = (Grajdan) CreateInstance(Type.GetType(data[0].FullName), b[1], b[0]);
                            qc.Add(grajdan);
                            break;
                    }
                }
            var sortedArray = new Architect[qc.Count];
            for (var i = 0; i < qc.Count; i++)
                sortedArray[i] = qc[i];
            var heap = new Heap<Architect>(sortedArray);
            heap.HeapSort();

            var savingList = new List<string>();
            for (var i = 0; i < sortedArray.Length; i++)
                savingList.Add(sortedArray[i].ToString());

            File.WriteAllLines("output.txt", savingList);
        }
    }

    public class StringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.Compare(x, y, StringComparison.Ordinal);
        }
    }
}