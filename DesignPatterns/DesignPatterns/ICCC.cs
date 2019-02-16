using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class ICCC : Imposto
    {
        public ICCC(Imposto outroImposto) : base(outroImposto) { }
        public ICCC() : base() { }

        public override double Calcula(Orcamento orcamento)
        {
            if (orcamento.Valor > 3000.0)
            {
                return orcamento.Valor * 0.08 + 30.0;
            }
            else if (orcamento.Valor > 1000)
            {
                return orcamento.Valor * 0.07;
            }
            else
            {
                return orcamento.Valor * 0.05;
            }
        }
    }
}
