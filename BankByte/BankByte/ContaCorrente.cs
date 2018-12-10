using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankByte
{
    class ContaCorrente
    {
        public Cliente Titular { get; set; }
        public static int TotalContasCriadas { get; private set; } // Static é uma propriedade da classe e não de uma instancia
        public int Agencia { get; set; }
        public int Numero { get; set; }
        private double _saldo = 100;  // _ Convenção para propriedades privadas

        public ContaCorrente(int agencia, int numero) {
            this.Agencia = agencia;
            this.Numero = numero;
            ContaCorrente.TotalContasCriadas++;
        }

        public double Saldo {
            get {
                return this._saldo;
            }
            set {
                if (value < 0) {
                    return;
                }

                this._saldo = value;
            }
        }

        public bool Sacar(double valor) {
            if (this._saldo < valor) {
                return false;
            }

            this._saldo -= valor;
            return true;
        }

        public void Depositar(double valor) {
            this._saldo += valor;
        }

        public bool Transferir(double valor, ContaCorrente contaDestino) {
            bool saque = this.Sacar(valor);

            if (!saque) {
                return false;
            }

            contaDestino.Depositar(valor);
            return true;
        }
    }
}
