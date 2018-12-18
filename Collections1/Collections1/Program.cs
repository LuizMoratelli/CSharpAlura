using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections1
{
    class Program
    {
        static void Main(string[] args)
        {
            string aulaIntro = "Introdução às Coleções";
            string aulaModelando = "Modelando a Classe Aula";
            string aulaSets = "Trabalhando com Conjuntos";

            //string[] aulas = new string[]
            //{
            //    aulaIntro,
            //    aulaModelando,
            //    aulaSets
            //};

            string[] aulas = new string[3];
            aulas[0] = aulaIntro;
            aulas[1] = aulaModelando;
            aulas[2] = aulaSets;

            // cw
            Console.WriteLine(aulas);
            Imprimir(aulas);

            Console.WriteLine(aulas[0]);
            Console.WriteLine(aulas[aulas.Length - 1]);

            aulaIntro = "Trabalhando com Arrays";
            Imprimir(aulas);

            aulas[0] = "Trabalhando com Arrays";

            // Primeiro match
            Console.WriteLine($"Aula modelando está no índice " + Array.IndexOf(aulas, aulaModelando));
            // Ultimo match
            Console.WriteLine(Array.LastIndexOf(aulas, aulaModelando));

            // Array invertido
            // Idempotente (se executar 2x volta ao normal)
            Array.Reverse(aulas);
            Imprimir(aulas);

            // Redimensionar o array
            // Copia interna invisível
            Array.Resize(ref aulas, 2);
            Imprimir(aulas);

            Array.Resize(ref aulas, 3);
            // 2 = número mágico
            aulas[aulas.Length - 1] = "Conclusão";
            Imprimir(aulas);

            Array.Sort(aulas);
            Imprimir(aulas);

            string[] copia = new string[2];
            // Copia os 2 ultimos elementos para o copia
            Array.Copy(aulas, 1, copia, 0, 2);

            string[] clone = aulas.Clone() as string[];
            Imprimir(clone);

            // Limpa os 2 ultimos elementos
            Array.Clear(clone, 1, 2);
            Imprimir(clone);

            Console.ReadLine();
        }

        // Ctrl + . para transformar seleção em método
        private static void Imprimir(string[] aulas)
        {
            //foreach (var aula in aulas)
            //{
            //    Console.WriteLine(aula);
            //}

            for (int i = 0; i < aulas.Length; i++)
            {
                Console.WriteLine(aulas[i]);
            }
        }
    }
}
