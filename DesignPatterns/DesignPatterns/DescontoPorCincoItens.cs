using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class DescontoPorCincoItens : TemplateDeDescontoCondicional
    {
        protected override double AplicarDescontoNo(Orcamento orcamento)
        {
            return orcamento.Valor * 0.1;
        }

        protected override bool DeveAplicarDescontoNo(Orcamento orcamento)
        {
            return orcamento.Itens.Count() > 5;
        }
    }
}
