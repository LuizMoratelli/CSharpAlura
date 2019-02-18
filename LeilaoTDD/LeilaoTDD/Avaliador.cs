using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeilaoTDD
{
    public class Avaliador
    {
        private double maiorDeTodos = double.MinValue;
        private double menorDeTodos = double.MaxValue;
        private double mediaDosLances = 0;
        private List<Lance> maioresLances;

        public void Avalia(Leilao leilao)
        {
            if (leilao.Lances.Count == 0) throw new Exception("Um leilão deve possuir pelo menos um lance!");

            foreach (Lance lance in leilao.Lances)
            {
                if (lance.Valor > maiorDeTodos) maiorDeTodos = lance.Valor;
                if (lance.Valor < menorDeTodos) menorDeTodos = lance.Valor;
                mediaDosLances+=lance.Valor;
            }
            mediaDosLances/=leilao.Lances.Count();
            pegaOsMaioresNo(leilao);
        }

        private void pegaOsMaioresNo(Leilao leilao)
        {
            //linq
            maioresLances = new List<Lance>(leilao.Lances.OrderByDescending(x => x.Valor));
            maioresLances = maioresLances.GetRange(0, maioresLances.Count > 3 ? 3 : maioresLances.Count);
        }

        public double MaiorLance {
            get { return maiorDeTodos; }
        }

        public double MenorLance {
            get { return menorDeTodos; }
        }

        public double MediaDosLances {
            get { return mediaDosLances; }
        }

        public List<Lance> TresMaiores {
            get { return maioresLances; }
        }
    }
}
