using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections2
{
    public class Aluno
    {
        public string Nome { get; private set; }
        public int NumeroMatricula { get; private set; }

        public Aluno(string nome, int numeroMatricula)
        {
            Nome = nome;
            NumeroMatricula = numeroMatricula;
        }

        public override string ToString()
        {
            return "Aluno: " + Nome + ", matricula: " + NumeroMatricula;
        }
    }
}
