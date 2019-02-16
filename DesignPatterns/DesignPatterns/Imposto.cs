using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public abstract class Imposto
    {
        public Imposto OutroImposto { get; set; }

        public Imposto()
        {
            OutroImposto = null;
        }

        public Imposto(Imposto outroImposto)
        {
            OutroImposto = outroImposto;
        }

        public abstract double Calcula(Orcamento orcamento);

        protected double calculoDoOutroImposto(Orcamento orcamento)
        {
            if (OutroImposto == null) return 0;
            return OutroImposto.Calcula(orcamento);
        }
    }
}
