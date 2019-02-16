using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Imposto iss = new ImpostoMuitoAlto(new ISS(new ICMS(new IKCV(new IHIT()))));
            Orcamento orcamento = new Orcamento(500);
            double valor = iss.Calcula(orcamento);
            Console.WriteLine(valor);
        }
    }
}
