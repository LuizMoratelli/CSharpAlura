using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections1
{
    public class Aula : IComparable
    {
        private string titulo;
        private int tempo;

        public Aula(string titulo, int tempo)
        {
            this.titulo = titulo;
            this.tempo = tempo;
        }

        public string Titulo { get => titulo; set => titulo = value; }
        public int Tempo { get => tempo; set => tempo = value; }

        public int CompareTo(object obj)
        {
            var outraAula = obj as Aula;

            return Titulo.CompareTo(outraAula.Titulo);
        }

        public override string ToString()
        {
            return $"[título: {Titulo}, tempo: {Tempo} minutos.]";
        }


    }
}
