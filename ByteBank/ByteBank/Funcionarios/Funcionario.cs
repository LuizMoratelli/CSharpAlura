﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Funcionarios
{
    // Se não faz sentido instanciar a classe e apenas serve de base ela será abstrata
    public abstract class Funcionario
    {
        public string Nome { get; set; }
        public string CPF { get; private set; }
        // Funciona como publico para as classes filhas e privado para as demais
        public double Salario { get; protected set; }
        public static int TotalDeFuncionarios { get; private set; }

        public Funcionario(double salario, string cpf) {
            TotalDeFuncionarios++;
            this.CPF = cpf;
            this.Salario = salario;
        }

        // Construtor que é chamado caso não seja informado o salário
        // Ele chama o próprio construtor mais complexo
        public Funcionario(string cpf) : this(1500, cpf) {

        }

        //public virtual void AumentarSalario() {
        //    Salario *= 1.1;
        //}
        public abstract void AumentarSalario();

        // Quando existe processamento (não gratuíto) é uma convenção ser um método
        // Virtual, permite que filhos sobreescrevam a implementação
        //public virtual double GetBonificacao() { 
        //    return Salario * 0.1;
        //}

        // Usa-se abstract para obrigar a implementação do métodos pelas classes que herdarem essa classe
        // Se a classe é abstract os métodos também serão abstract.
        public abstract double GetBonificacao();
    }
}
