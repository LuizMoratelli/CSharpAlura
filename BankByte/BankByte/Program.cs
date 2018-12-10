using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankByte
{
    class Program
    {
        static void Main(string[] args) {
            ContaCorrente conta = new ContaCorrente(123, 123456);

            ContaCorrente conta2 = new ContaCorrente(123, 123457);
            conta2.Transferir(100, conta);

            Console.WriteLine(conta.Saldo);
            Console.WriteLine(conta2.Saldo);
            Console.WriteLine(ContaCorrente.TotalContasCriadas);
            Console.ReadLine();
        }
    }
}
