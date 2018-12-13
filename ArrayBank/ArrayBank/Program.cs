using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayBank
{
    class Program
    {
        static void Main(string[] args) {
            Console.ReadLine();
        }

        static void TestaArray() {
            // Array de inteiros
            int[] idades = new int[5];
            int media = 0;

            idades[0] = 14;
            idades[1] = 25;
            idades[2] = 31;
            idades[3] = 08;
            idades[4] = 24;

            for (int i = 0; i < idades.Length; i++) {
                media += idades[i];
            }

            media /= idades.Length;

            Console.WriteLine(media);
        }
    }
}
