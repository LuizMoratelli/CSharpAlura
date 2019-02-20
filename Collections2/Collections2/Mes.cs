using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections2
{
    public class Mes : IComparable
    {
        public string Nome { get; private set; }
        public int QuantidadeDias { get; private set; }

        public Mes(string nome, int quantidadeDias)
        {
            Nome = nome;
            QuantidadeDias = quantidadeDias;
        }

        public override string ToString()
        {
            return $"{Nome} - {QuantidadeDias}";
        }

        public int CompareTo(object obj)
        {
            Mes outro = obj as Mes;
            return Nome.CompareTo(outro.Nome);
        }
    }
}
