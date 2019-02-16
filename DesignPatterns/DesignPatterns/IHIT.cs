using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class IHIT : TemplateDeImpostoCondicional
    {
        protected override bool DeveUsarMaximaTaxacao(Orcamento orcamento)
        {
            return existemDoisItensComOMesmoNome(orcamento);
        }

        private bool existemDoisItensComOMesmoNome(Orcamento orcamento)
        {
            IList<string> noOrcamento = new List<string>();

            foreach (Item item in orcamento.Itens)
            {
                if (noOrcamento.Contains(item.Nome)) return true;
                noOrcamento.Add(item.Nome);
            }

            return false;
        }

        protected override double MaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.13 + 100.0;
        }

        protected override double MinimaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.01 * orcamento.Itens.Count();
        }
    }
}
