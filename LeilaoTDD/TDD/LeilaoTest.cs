using System;
using LeilaoTDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDD
{
    [TestClass]
    public class LeilaoTest
    {
        [TestMethod]
        public void DeveReceberUmLance()
        {
            Leilao leilao = new Leilao("MacBook Pro 15");
            Assert.AreEqual(0, leilao.Lances.Count);

            leilao.Propoe(new Lance(new Usuario("Steve Jobs"), 2000));
            Assert.AreEqual(1, leilao.Lances.Count);
            Assert.AreEqual(2000, leilao.Lances[0].Valor, 0.0001);
        }

        [TestMethod]
        public void DeveReceberVariosLances()
        {
            Leilao leilao = new Leilao("MacBook Pro 15");
            leilao.Propoe(new Lance(new Usuario("Steve Jobs"), 2000));
            leilao.Propoe(new Lance(new Usuario("Steve Wozniak"), 3000));

            Assert.AreEqual(2, leilao.Lances.Count);
            Assert.AreEqual(2000, leilao.Lances[0].Valor, 0.0001);
            Assert.AreEqual(3000, leilao.Lances[1].Valor, 0.0001);
        }

        [TestMethod]
        public void NaoDeveAceitarDoisLancesSeguidosDoMesmoUsuario() 
        {
            Leilao leilao = new Leilao("MacBook Pro 15");
            Usuario steveJobs = new Usuario("Steve Jobs");
            leilao.Propoe(new Lance(steveJobs, 2000));
            leilao.Propoe(new Lance(steveJobs, 3000));

            Assert.AreEqual(1, leilao.Lances.Count);
            Assert.AreEqual(2000, leilao.Lances[0].Valor, 0.0001);
        }

        [TestMethod]
        public void NaoDeveAceitarMaisQueCincoLancesDoMesmoUsuario()
        {
            Leilao leilao = new Leilao("Carro esportivo");
            Usuario steveJobs = new Usuario("Steve Jobs");
            Usuario steveWozniak = new Usuario("Steve Wozniak");
            leilao.Propoe(new Lance(steveJobs, 2000));
            leilao.Propoe(new Lance(steveWozniak, 3000));
            leilao.Propoe(new Lance(steveJobs, 3100));
            leilao.Propoe(new Lance(steveWozniak, 3200));
            leilao.Propoe(new Lance(steveJobs, 3300));
            leilao.Propoe(new Lance(steveWozniak, 3400));
            leilao.Propoe(new Lance(steveJobs, 3500));
            leilao.Propoe(new Lance(steveWozniak, 3600));
            leilao.Propoe(new Lance(steveJobs, 3800));
            leilao.Propoe(new Lance(steveWozniak, 3800));

            leilao.Propoe(new Lance(steveJobs, 3900));

            Assert.AreEqual(10, leilao.Lances.Count);
            var ultimo = leilao.Lances.Count - 1;
            Lance ultimoLance = leilao.Lances[ultimo];

            Assert.AreEqual(3800, ultimoLance.Valor, 0.0001);
        }
    }
}
