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
        static void Main(string[] args)
        {
            //EscritaBinaria();
            //LeituraBinaria();

            UsarStreamEntrada();

            CriarArquivoStreamWritter();

            using (var fs = new FileStream("testaTipos.txt", FileMode.Create))
            using (var escritor = new StreamWriter(fs))
            {

            }

            var nome = Console.ReadLine();

            // Não necessário utilizar o StreamReader
            // Le o arquivo inteiro de uma vez, CUIDADO, as vezes melhor usar o StreamReader
            var linhas = File.ReadAllLines("contas.txt");

            // Escrita simples, para coisas pequenas
            File.WriteAllText("Testando file", "testeWrite.txt");

            Console.ReadLine();
        }

        static void CriarArquivoStreamWritter()
        {
            var contasExportadas = "contasExportadas.csv";
            // CreateNew só cria se não existe
            // Create se existe ele apaga e cria um novo
            using (var fluxoArquivo = new FileStream(contasExportadas, FileMode.Create))
            // Implementa o IDisposable
            using (var escritor = new StreamWriter(fluxoArquivo))
            {
                escritor.Write("123,123,34.60,Luiz");
            }
        }

        static void EscreveImediatamenteLog()
        {
            var arquivo = "teste.log";

            using (var fluxoArquivo = new FileStream(arquivo, FileMode.Create))
            using (var escritor = new StreamWriter(fluxoArquivo))
            {
                for (int i = 0; i < 100000 ; i++)
                {
                    escritor.WriteLine(i);
                    escritor.Flush();

                    Console.ReadLine();
                }
            }
        }

        static void CriarArquivo() 
        {
            var caminhoNovoArquivo = "contasExportadas.csv";

            using (var fluxoArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            {
                var contaComoString = "123,45,129.50,Gustavo Santos";
                var encoding = Encoding.UTF8;
                var bytes = encoding.GetBytes(contaComoString);

                fluxoArquivo.Write(bytes, 0, bytes.Length);
            }
        }
    }
}
