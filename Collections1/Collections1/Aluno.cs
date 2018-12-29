﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections1
{
    public class Aluno
    {
        private string nome;
        private int numeroMatricula;

        public Aluno(string nome, int numeroMatricula)
        {
            this.nome = nome;
            this.numeroMatricula = numeroMatricula;
        }

        public string Nome {
            get { return nome; }
            set { nome = value; }
        }

        public int NumeroMatricula {
            get { return numeroMatricula; }
            set { numeroMatricula = value; }
        }

        public override string ToString()
        {
            return $"[Nome: {Nome}, Matrícula: {numeroMatricula}]";
        }

        public override bool Equals(object obj)
        {
            Aluno outro = obj as Aluno;

            if (outro == null)
                return false;

            return this.nome.Equals(outro.nome);
        }

        // Sempre que implementa Equals também deve implementar
        public override int GetHashCode()
        {
            return this.nome.GetHashCode();
        }
    }
}
