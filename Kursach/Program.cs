using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Activator;
using static System.Console;

namespace Kursach
{
    partial class Program
    { 
        static void Main(string[] args)
        {
            string outputtext;
            using (FileStream fstream = new FileStream("new.txt",FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                outputtext = System.Text.Encoding.Default.GetString(array);
            }

            

            QueueCustom qc = new QueueCustom();
            foreach (var fullArray in outputtext.Split('\n'))
            {
                if (fullArray != String.Empty)
                {
                string[] a = fullArray.Split(':');
                string[] b = a[1].Split(' ');
                    var data =
                        Assembly.LoadFrom("Kursach.exe")
                            .DefinedTypes.ToList()
                            .FindAll(type => type.IsSubclassOf(typeof(Architect))).ToArray();


                    switch (a[0])
                    {
                        case "Религия":
                            Relig relig = (Relig)CreateInstance(Type.GetType(data[2].FullName),b[1],b[0]);
                            qc.Add(relig);
                            break;
                        case "Правительство":
                            Pravit pravit = (Pravit)CreateInstance(Type.GetType(data[1].FullName),b[1],b[0]);
                            qc.Add(pravit);
                            break;
                        case "Гражданство":
                            Grajdan grajdan = (Grajdan)CreateInstance(Type.GetType(data[0].FullName),b[1],b[0]);
                            qc.Add(grajdan);
                            break;
                    }
                }

            }

            List<string> savingList = new List<string>();
            var count = qc.Count;
            for (int i = 0; i < count; i++)
            {
                savingList.Add(qc[i].ToString());
            }




            Sort(savingList.ToArray(), 0, count, string.Compare);
            File.WriteAllLines("output.txt", savingList);

            
        }
    }
}
