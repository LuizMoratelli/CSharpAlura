using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class DescontoPorVendaCasada : Desconto
    {
        public Desconto Proximo { get; set; }

        public double Desconta(Orcamento orcamento)
        {
            if (AconteceuVendaCasadaEm(orcamento)) return orcamento.Valor * 0.05;
            else return Proximo.Desconta(orcamento);
        }

        private bool AconteceuVendaCasadaEm(Orcamento orcamento)
        {
            return Existe("Caneta", orcamento) && Existe("Lapis", orcamento);
        }

        private bool Existe(string nomeDoItem, Orcamento orcamento)
        {
            foreach (Item item in orcamento.Itens)
            {
                if (nomeDoItem.Equals(item.Nome)) return true;
            }

            return false;
        }
    }
}
