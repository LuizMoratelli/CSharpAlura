using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class DescontoPorMaisDeQuinhentosReais : TemplateDeDescontoCondicional
    {

        protected override double AplicarDescontoNo(Orcamento orcamento)
        {
            return orcamento.Valor * 0.07;
        }

        protected override bool DeveAplicarDescontoNo(Orcamento orcamento)
        {
            return orcamento.Valor > 500.0;
        }
    }
}
