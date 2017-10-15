using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputtext;
            using (FileStream fstream = new FileStream("/new.txt",FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                outputtext = System.Text.Encoding.Default.GetString(array);
            }
            Console.WriteLine(outputtext);

            Architect relig = new Relig();
            Architect pravit = new Pravit();
            Architect grajdan = new Grajdan();

            Console.ReadKey();
        }
    }
}
