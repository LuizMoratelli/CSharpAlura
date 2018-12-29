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
        // Implementando Dicionario
        private IDictionary<int, Aluno> dicionarioAlunos = new Dictionary<int, Aluno>();

        //propfull
        private IList<Aula> aulas;

        // Proteção, somente leitura
        public IList<Aula> Aulas {
            get { return new ReadOnlyCollection<Aula>(aulas); }
        }

        private ISet<Aluno> alunos = new HashSet<Aluno>();
        public IList<Aluno> Alunos {
            get {
                return new ReadOnlyCollection<Aluno>(alunos.ToList());
            }
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

        internal void Matricular(Aluno aluno)
        {
            alunos.Add(aluno);
            this.dicionarioAlunos.Add(aluno.NumeroMatricula, aluno);
        }

        public string Instrutor {
            get { return instrutor; }
            set { instrutor = value; }
        }

        // Sem dicionaio
        //internal string BuscaMatriculado(int numeroMatricula)
        //{
        //    foreach (var aluno in alunos)
        //    {
        //        if (aluno.NumeroMatricula == numeroMatricula)
        //            return aluno.Nome;
        //    }

        //    throw new Exception($"Matrícula não encontrada: {numeroMatricula}");
        //}

        // Com dicionario
        public Aluno BuscaMatriculado(int numeroMatricula)
        {
            // Não seguro
            //return dicionarioAlunos[numeroMatricula];
            // Seguro (trata se não tem)
            Aluno aluno = null;
            dicionarioAlunos.TryGetValue(numeroMatricula, out aluno);
            return aluno;
        }

        public void SubstituiAluno(Aluno aluno)
        {
            this.dicionarioAlunos[aluno.NumeroMatricula] = aluno;
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

        public bool EstaMatriculado(Aluno aluno)
        {
            return alunos.Contains(aluno);
        }
    }
}
