using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankImpExp
{
    partial class Program
    {
        static void EscritaBinaria()
        {
            using (var fs = new FileStream("contaCorrente.txt", FileMode.Create)) 
            using (var escritor = new BinaryWriter(fs))
            {
                escritor.Write(123);
                escritor.Write(423.50);
                escritor.Write("AaaaB");
            }
        }

        static void LeituraBinaria()
        {
            using (var fs = new FileStream("contaCorrente.txt", FileMode.Open))
            using (var leitor = new BinaryReader(fs))
            {
                var agencia = leitor.ReadInt32();
                var saldo = leitor.ReadDouble();
                var nomeTitular = leitor.ReadString();

                Console.WriteLine($"Agencia: {agencia}, Saldo: {saldo}, Nome: {nomeTitular}");
            }
        }
    }
}
