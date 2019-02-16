using System.Collections.Generic;

namespace LeilaoTDD
{
    public class Leilao
    {
        public string Descricao { get; set; }
        public IList<Lance> Lances { get; set; }

        public Leilao(string descricao)
        {
            Descricao = descricao;
            Lances = new List<Lance>();
        }

        public void Propoe(Lance lance)
        {
            if (Lances.Count == 0 || PodeDarLance(lance.Usuario))
            {
                Lances.Add(lance);
            }
        }

        private bool PodeDarLance(Usuario usuario)
        {
            return (!ultimoLanceDado().Usuario.Equals(usuario) && totalDeLancesDo(usuario) < 5);
        }

        private int totalDeLancesDo(Usuario usuario)
        {
            int total = 0;
            foreach (Lance l in Lances)
            {
                if (l.Usuario.Equals(usuario)) total++;
            }

            return total;
        }

        private Lance ultimoLanceDado()
        {
            return Lances[Lances.Count - 1];
        }
    }
}
