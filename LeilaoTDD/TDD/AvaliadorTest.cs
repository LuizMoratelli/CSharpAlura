using System;
using LeilaoTDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//https://docs.microsoft.com/pt-br/visualstudio/test/getting-started-with-unit-testing?view=vs-2017

namespace TDD
{
    [TestClass]
    public class AvaliadorTest
    {
        [TestMethod]
        public void DeveEntenderLancesEmOrdemCrescente()
        {
            //cenario
            Usuario joao = new Usuario("Joao");
            Usuario jose = new Usuario("Jose");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Playstation 3 Novo");
            leilao.Propoe(new Lance(joao, 300));
            leilao.Propoe(new Lance(jose, 400));
            leilao.Propoe(new Lance(maria, 250));

            //acao
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            //validacao
            double maiorEsperado = 400;
            double menorEsperado = 250;

            //Assert faz as verificacoes
            Assert.AreEqual(maiorEsperado, leiloeiro.MaiorLance);
            Assert.AreEqual(menorEsperado, leiloeiro.MenorLance);
         
        }

        [TestMethod]
        public void DeveCalcularAMedia()
        {
            Usuario joao = new Usuario("Joao");
            Usuario jose = new Usuario("Jose");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Playstation 3 Novo");
            leilao.Propoe(new Lance(joao, 300));
            leilao.Propoe(new Lance(jose, 400));
            leilao.Propoe(new Lance(maria, 500));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            double mediaEsperada = 400;
            Assert.AreEqual(mediaEsperada, leiloeiro.MediaDosLances, 0.0001);
        }

        [TestMethod]
        public void DeveEntenderLeilaoComApenasUmLance()
        {
            Usuario joao = new Usuario("Joao");
            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(joao, 1000));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            Assert.AreEqual(1000, leiloeiro.MaiorLance, 0.0001);
            //0.0001 taxa de erro
            Assert.AreEqual(1000, leiloeiro.MenorLance, 0.0001);
        }

        [TestMethod]
        public void DeveEncontrarOsTresMaioresLances()
        {
            Usuario joao = new Usuario("Joao");
            Usuario maria = new Usuario("maria");
            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(joao, 100));
            leilao.Propoe(new Lance(maria, 200));
            leilao.Propoe(new Lance(joao, 300));
            leilao.Propoe(new Lance(maria, 400));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            //Sempre que for lista, verificar o conteudo e tamanho
            //Classe de equivalencia = conjunto unico de teste
            var maiores = leiloeiro.TresMaiores;
            Assert.AreEqual(3, maiores.Count);
            Assert.AreEqual(400, maiores[0].Valor, 0.0001);
            Assert.AreEqual(300, maiores[1].Valor, 0.0001);
            Assert.AreEqual(200, maiores[2].Valor, 0.0001);
        }
    }
}