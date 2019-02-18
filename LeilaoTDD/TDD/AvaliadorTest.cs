using System;
using LeilaoTDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//https://docs.microsoft.com/pt-br/visualstudio/test/getting-started-with-unit-testing?view=vs-2017
//https://stackoverflow.com/questions/14461737/visual-studio-unit-testing-setup-and-teardown

namespace TDD
{
    [TestClass]
    public class AvaliadorTest
    {
        private Avaliador leiloeiro;
        private Usuario joao;
        private Usuario jose;
        private Usuario maria;

        //Sempre executa antes dos métodos de teste
        [TestInitialize]
        public void CriaAvaliador()
        {
            leiloeiro = new Avaliador();
            joao = new Usuario("Joao");
            jose = new Usuario("Jose");
            maria = new Usuario("Maria");
        }

        [TestMethod]
        public void DeveEntenderLancesEmOrdemCrescente()
        {
            //cenario
            Leilao leilao = new Leilao("Playstation 3 Novo");
            leilao.Propoe(new Lance(joao, 300));
            leilao.Propoe(new Lance(jose, 400));
            leilao.Propoe(new Lance(maria, 250));

            //acao
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
            Leilao leilao = new Leilao("Playstation 3 Novo");
            leilao.Propoe(new Lance(joao, 300));
            leilao.Propoe(new Lance(jose, 400));
            leilao.Propoe(new Lance(maria, 500));

            leiloeiro.Avalia(leilao);

            double mediaEsperada = 400;
            Assert.AreEqual(mediaEsperada, leiloeiro.MediaDosLances, 0.0001);
        }

        [TestMethod]
        public void DeveEntenderLeilaoComApenasUmLance()
        {
            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(joao, 1000));

            leiloeiro.Avalia(leilao);

            Assert.AreEqual(1000, leiloeiro.MaiorLance, 0.0001);
            //0.0001 taxa de erro
            Assert.AreEqual(1000, leiloeiro.MenorLance, 0.0001);
        }

        [TestMethod]
        public void DeveEncontrarOsTresMaioresLances()
        {
            // Padrão Teste Data Builder
            Leilao leilao = new CriadorDeLeilao().Para("Playstation")
                .Lance(joao, 100)
                .Lance(maria, 200)
                .Lance(joao, 300)
                .Lance(maria, 400)
                .Constroi();

            leiloeiro.Avalia(leilao);

            //Sempre que for lista, verificar o conteudo e tamanho
            //Classe de equivalencia = conjunto unico de teste
            var maiores = leiloeiro.TresMaiores;
            Assert.AreEqual(3, maiores.Count);
            Assert.AreEqual(400, maiores[0].Valor, 0.0001);
            Assert.AreEqual(300, maiores[1].Valor, 0.0001);
            Assert.AreEqual(200, maiores[2].Valor, 0.0001);
        }

        [TestMethod]
        //Esperará tal tipo de exceção
        [ExpectedException(typeof(Exception))]
        public void NaoDeveAvaliarLeiloesSemNenhumLance()
        {
            Leilao leilao = new CriadorDeLeilao().Para("Geladeira").Constroi();
            leiloeiro.Avalia(leilao);
        }
    }
}