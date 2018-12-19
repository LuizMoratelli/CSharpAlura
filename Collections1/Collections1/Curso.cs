using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections1
{
    public class Curso
    {
        //propfull
        private IList<Aula> aulas;

        // Proteção, somente leitura
        public IList<Aula> Aulas {
            get { return new ReadOnlyCollection<Aula>(aulas); }
        }

        private string nome;
        private string instrutor;

        public Curso(string nome, string instrutor)
        {
            this.nome = nome;
            this.instrutor = instrutor;
            this.aulas = new List<Aula>();
        }

        public string Nome {
            get { return nome; }
            set { nome = value; }
        }

        public string Instrutor {
            get { return instrutor; }
            set { instrutor = value; }
        }

        internal void Adicionar(Aula aula)
        {
            this.aulas.Add(aula);
        }

        public int TempoTotal
        {
            get 
            {
                //int total = 0;
                //foreach (var aula in aulas)
                //{
                //    total += aula.Tempo;
                //}

                //return total;
                // LINQ = Language Integrated Query
                // COnsulta Integrada à Linguagem
                return aulas.Sum(aula => aula.Tempo);
            }
        }

        public override string ToString()
        {
            return $"Curso: {Nome}, Tempo: {TempoTotal}, Aulas: {String.Join(",", aulas)}";
        }
    }
}
