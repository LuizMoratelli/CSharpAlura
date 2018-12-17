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
        static void UsarStreamEntrada()
        {
            using (var fluxoEntrada = Console.OpenStandardInput())
            using (var fs = new FileStream("entradaConsole.txt", FileMode.Create))
            {
                var buffer = new byte[1024];

                while(true)
                {
                    var bytesLidos = fluxoEntrada.Read(buffer, 0, 1024);
                    fs.Write(buffer, 0, bytesLidos);

                    // Despeja os dados mesmo antes de fechar o arquivo
                    fs.Flush();

                    Console.WriteLine($"Bytes lidos da console: {bytesLidos}");
                }
            } 
        }
    }
}
