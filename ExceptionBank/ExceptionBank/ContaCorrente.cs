using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionBank
{
    public class ContaCorrente
    {
        public static double TaxaOperacao { get; private set; }

        public static int TotalDeContasCriadas { get; set; }

        public Cliente Titular { get; set; }

        public int ContadorSaquesNaoPermitidos { get; private set; }
        public int ContadorTransferenciasNaoPermitidos { get; private set; }

        // Campo somente leitura só pode ser atribuido no construtor
        /* private readonly int _numero;
        public int Numero { 
            get {
                return _numero;
            }
        } */

        // Cria apenas como leitura
        public int Numero { get; }
        public int Agencia { get; }

        private double _saldo = 100;
        public double Saldo {
            get {
                return _saldo;
            }
            private set {
                if (value < 0) {
                    return;
                }

                _saldo = value;
            }
        }

        public ContaCorrente(int numeroAgencia, int numeroConta) {
            if (numeroAgencia <= 0) {
                // Exceção
                // Exception excecao = new Exception("A agência e o número devem ser maiores que 0");
                // Exceção do tipo de argumento
                //ArgumentException e = new ArgumentException("A agência deve ser maior que 0.");
                //throw e;
                // nameof - Operador não método - retorna o nome do membro, para não ser estático.
                throw new ArgumentException("A agência deve ser maior que 0.", nameof(numeroAgencia));
            }
            
            if (numeroConta <= 0) {
                throw new ArgumentException("O número deve ser maior que 0.", nameof(numeroConta));
            }

            Agencia = numeroAgencia;
            Numero = numeroConta;

            TotalDeContasCriadas++;

            TaxaOperacao = 30 / TotalDeContasCriadas;
        }

        public void Sacar(double valor) {
            if (valor < 0) {
                throw new ArgumentException("Valor inválido para o saque.", nameof(valor));
            }

            if (valor > Saldo) {
                ContadorSaquesNaoPermitidos++;
                throw new SaldoInsuficienteException(Saldo, valor);
            }

            Saldo -= valor;
        }

        public void Depositar(double valor) {
            Saldo += valor;
        }

        public void Transferir(double valor, ContaCorrente contaDestino) {
            if (valor < 0) {
                throw new ArgumentException("Valor inválido para transferência.", nameof(valor));
            }

            try { 
                Sacar(valor);
            } catch (SaldoInsuficienteException e) {
                ContadorTransferenciasNaoPermitidos++;
                // throw (momento de preencher stacktrace)
                // Caso vazio apenas propaga a exceção, com preenchimento limpa rastro
                throw new OperacaoFinanceiraException("Operação não realizada", e);
            }

            //CTRL K C para comentar bloco de linhas selecionada

            contaDestino.Depositar(valor);
        }
    }
}
