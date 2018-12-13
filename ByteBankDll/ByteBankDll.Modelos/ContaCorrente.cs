using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Solução Modelos >> Propriedades >> Build >> XML
namespace ByteBankDll.Modelos
{
    /// <summary>
    /// Define uma Conta Corrente do Banco ByteBank.
    /// </summary>
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

        /// <summary>
        /// Cria uma instância de Conta Corrente com os argumentos utilizados.
        /// </summary>
        /// <param name="numeroAgencia">Representa o valor da propriedade <see cref="Agencia"/> e deve possuir um valor maior que 0.</param>
        /// <param name="numeroConta">Representa o valor da propriedade <see cref="Numero"/> e deve possuir um valor maior que 0.</param>
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

        /// <summary>
        /// Realiza o saque a atualiza o valor da propriedade <see cref="Saldo"/>.
        /// </summary>
        /// <exception cref="ArgumentException">Exceção lançada quando um valor negativo é utilizado no argumento <paramref name="valor"/>.</exception>
        /// <exception cref="SaldoInsuficienteException">Exceção lançada quando o valor de <paramref name="valor"/> é maior que o valor da propriedade <see cref="Saldo"/></exception>
        /// <param name="valor">Reprensenta o valor do saque, deve ser maior que 0 e menor que o <see cref="Saldo"/>.</param>
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

        public override string ToString() {
            //return "Numero " + Numero + ", Agencia " + Agencia;
            // Com $ no começo da string pode-se usar {variaveis} 
            return $"Numero {Numero}, Agencia {Agencia}";
        }

        public override bool Equals(object obj) {
            ContaCorrente outraConta = obj as ContaCorrente; //lança null ao inves de exception

            if (outraConta == null)
                return false;

            return Numero == outraConta.Numero && Agencia == outraConta.Agencia;
        }
    }
}
