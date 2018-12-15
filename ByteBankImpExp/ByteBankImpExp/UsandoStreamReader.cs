using ByteBankImpExp.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankImpExp
{
    // Em todos os arquivos precisa ser adicionado o partial
    partial class Program
    {
        enum CoresBotao
        {
            Azul, //= 0
            Vermelho,//=1
            Amarelo//=2
        }

        class Botao
        {
            public string Texto { get; set; }
            public CoresBotao Cor { get; set; }
        }

        static void testaBotao()
        {
            var botao = new Botao();
            botao.Cor = CoresBotao.Amarelo;
            botao.Texto = "Eu sou um botão";

            // Lendo de um arquivo seria
            // botao.Cor = (CoresBotao) linhaDoArquivo;
        }

        static void UsandoStreamReader()
        {
            var enderecoArquivo = "contas.txt";

            //using (var fluxoArquivo = new FileStream(enderecoArquivo, FileMode.Open))
            //{
            //    // Leitor de Stream
            //    using (var leitor = new StreamReader(fluxoArquivo))
            //    {
            //        // Enquanto não chegou no fim continua
            //        while (!leitor.EndOfStream)
            //        {
            //            var linha = leitor.ReadLine();
            //            Console.WriteLine(linha);
            //        }
            //    }
            //}

            // Identação de 2 using
            using (var fluxoArquivo = new FileStream(enderecoArquivo, FileMode.Open))
            // StreamReader(fluxoArquivo, Encoding.UTF8)
            using (var leitor = new StreamReader(fluxoArquivo))
            {
                // Enquanto não chegou no fim continua
                while (!leitor.EndOfStream)
                {
                    var linha = leitor.ReadLine();
                    var contaCorrente = ConverterStringParaContaCorrente(linha);

                    //Console.WriteLine(linha);
                    var msg = $"Nome: {contaCorrente.Titular.Nome}, Agencia: {contaCorrente.Agencia}, Numero: {contaCorrente.Numero}, Saldo: {contaCorrente.Saldo}";
                    Console.WriteLine(msg);
                }
            }

            Console.ReadLine();

        }

        static ContaCorrente ConverterStringParaContaCorrente(string linha)
        {
            var campos = linha.Split(',');
            var agencia = int.Parse(campos[0]);
            var numero = int.Parse(campos[1]);
            var saldo = double.Parse(campos[2].Replace('.', ','));
            var nomeTitular = campos[3];

            var titular = new Cliente();
            titular.Nome = nomeTitular;

            var resultado = new ContaCorrente(agencia, numero);
            resultado.Depositar(saldo);
            resultado.Titular = titular;

            return resultado;
        }

    }
}
