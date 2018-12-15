using ByteBankImpExp.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankImpExp
{
    // Quando uma classe esta particionada, o compilador juntará os membros
    partial class Program
    {
        static void LidandoComStreamDiretamente()
        {
            var conta = new ContaCorrente(123, 123);

            // Procura no Bin/Debug
            var enderecoArquivo = "contas.txt";

            // Caso haja uma exceção, ou o arquivo seja null, como implementa IDisposable vai liberar o arquivo corretamente
            // Semelhante a fazer um try/finnally e verificando se é nulo, caso seja chama o método dispose (que por baixo chama close)
            using (var fluxoArquivo = new FileStream(enderecoArquivo, FileMode.Open))
            {
                // Array de bytes
                var bufferArquivo = new byte[1024]; // 1 KB
                var numeroBytesLidos = -1;

                while (numeroBytesLidos != 0)
                {
                    numeroBytesLidos = fluxoArquivo.Read(bufferArquivo, 0, 1024);
                    EscreverBuffer(bufferArquivo, numeroBytesLidos);
                }
            }

            Console.ReadLine();
        }

        static void EscreverBuffer(byte[] buffer, int bytesLidos)
        {
            //var utf8 = new UTF8Encoding();
            //var utf8 = Encoding.UTF8;
            var utf8 = Encoding.Default;
            var texto = utf8.GetString(buffer, 0, bytesLidos);

            Console.Write(texto);
            //foreach (var meuByte in texto)
            //{
            //    Console.Write(meuByte);
            //    Console.Write(" ");
            //}
        }
    }
}