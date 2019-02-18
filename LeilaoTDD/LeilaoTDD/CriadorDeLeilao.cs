using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeilaoTDD
{
    public class CriadorDeLeilao
    {
        private Leilao leilao;

        //Padrão de Builder devolve a própria classe para poder usar .Lance.Lance...
        public CriadorDeLeilao Para(string descricao)
        {
            leilao = new Leilao(descricao);
            return this;
        }

        public CriadorDeLeilao Lance(Usuario usuario, double valor)
        {
            leilao.Propoe(new Lance(usuario, valor));
            return this;
        }

        public Leilao Constroi()
        {
            return leilao;
        }
    }
}
