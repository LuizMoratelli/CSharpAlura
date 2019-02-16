using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public abstract class TemplateDeDescontoCondicional : Desconto
    {
        public Desconto Proximo { get; set; }

        public double Desconta(Orcamento orcamento)
        {
            if (DeveAplicarDescontoNo(orcamento))
            {
                return AplicarDescontoNo(orcamento);
            }

            return NaoAplicarDescontoNo(orcamento);
        }

        protected abstract bool DeveAplicarDescontoNo(Orcamento orcamento);
        protected abstract double AplicarDescontoNo(Orcamento orcamento);

        protected double NaoAplicarDescontoNo(Orcamento orcamento)
        {
            return Proximo.Desconta(orcamento);
        }
    }
}
