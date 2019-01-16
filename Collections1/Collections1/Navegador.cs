using System;
using System.Collections.Generic;
using System.Linq;

namespace Collections1
{
    internal class Navegador
    {
        private string atual = "vazia";
        private readonly Stack<string> historicoAnterior = new Stack<string>();
        private readonly Stack<string> historicoProximo = new Stack<string>();

        public Navegador()
        {
            Console.WriteLine("Página atual: " + atual);
        }

        internal void NavegarPara(string pagina)
        {
            historicoAnterior.Push(atual);
            atual = pagina;
            Console.WriteLine("Pagina atual: " + atual);
        }

        internal void Anterior()
        {
            if (historicoAnterior.Any())
            {
                historicoProximo.Push(atual);
                atual = historicoAnterior.Pop();
                Console.WriteLine("Pagina atual: " + atual);
            }
        }

        internal void Proximo()
        {
            if (historicoProximo.Any())
            {
                historicoAnterior.Push(atual);
                atual = historicoProximo.Pop();
                Console.WriteLine("Pagina atual: " + atual);
            }
        }
    }
}