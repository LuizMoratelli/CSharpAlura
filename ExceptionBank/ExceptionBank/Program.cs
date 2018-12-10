using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionBank
{
    class Program
    {
        static void Main(string[] args) {
            CarregarContas();

            Console.WriteLine("Execução finalizada. Tecle <enter> para sair.");
            Console.ReadLine();
        }

        private static void CarregarContas() {
            // try e finally verificando quando não é nula para dispose
            using(LeitorDeArquivo leitor = new LeitorDeArquivo("teste.txt")) {
                leitor.LerProximaLinha();
            }

            //LeitorDeArquivo leitor = null;

            //try {
            //    leitor = new LeitorDeArquivo("contas.txt");

            //    leitor.LerProximaLinha();
            //    leitor.LerProximaLinha();
            //    leitor.LerProximaLinha();
            //    leitor.Fechar();
            //} catch (IOException e) {
            //    Console.WriteLine(e.Message);
            //} finally {
            //    // Sempre é executado
            //    if (leitor != null)
            //        leitor.Fechar();
            //}
            
        }

        private static void TestaInnerException () {
            //try {
            //    ContaCorrente contaTeste = new ContaCorrente(0, 0);
            //} catch (ArgumentException e) {
            //    Console.WriteLine("Erro com o argumento " + e.ParamName + ".");
            //    Console.WriteLine(e.Message);
            //    Console.WriteLine(e.StackTrace);
            //} catch (Exception e) {
            //    Console.WriteLine(e.Message);
            //}

            //try {
            //    ContaCorrente saldo = new ContaCorrente (100, 100);
            //    saldo.Depositar(199);
            //    saldo.Sacar(500);
            //    Console.WriteLine(saldo.Saldo);
            //} catch (SaldoInsuficienteException e) {
            //    Console.WriteLine(e.Message);
            //} catch (Exception e) {
            //    Console.WriteLine(e.Message);
            //}

            //try {
            //    ContaCorrente conta = new ContaCorrente(123, 123);
            //} catch (Exception e) { // e por convenção
            //    Console.WriteLine(e.Message);
            //    // Permite sair de uma função com retorno (encerra o método/fluxo)
            //    // Passa o erro pra resto da pilha
            //    //throw;
            //}

            try {
                ContaCorrente conta1 = new ContaCorrente(123, 123);
                ContaCorrente conta2 = new ContaCorrente(123, 323);

                conta1.Transferir(1000, conta2);
            } catch (OperacaoFinanceiraException e) {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                // Exceção Interna
                Console.WriteLine(e.InnerException.StackTrace);
            }

            Console.ReadLine();
        }
    }
}
