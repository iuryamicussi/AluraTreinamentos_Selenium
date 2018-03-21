using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TesteAutomatizado.pages;

namespace TesteAutomatizado.testes
{
    [TestFixture]
    public class LanceSystemTest
    {
        private LeilaoPage leiloes;
        private IWebDriver driver;

        [OneTimeSetUp]
        public void InicializaUmaVez()
        {
            driver = new FirefoxDriver(@"C:\Users\user\Source\Repos\TesteAutomatizado\TesteAutomatizado\bin");
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            this.leiloes = new LeilaoPage(driver);
        }

        [SetUp]
        public void Inicializa()
        {
            new LimparAplicacao().LimparBanco(driver);

            new CriadorDeCenarios(driver)
                .umUsuario("Renan Saggio", "renan@caelum.com.br")
                .umUsuario("Mauricio", "mauricio@caelum.com.br")
                .umLeilao("Mauricio", "Geladeira", 250, true);
        }

        [OneTimeTearDown]
        public void Finaliza() => driver.Close();

        [Test]
        public void DeveDarLance()
        {
            var usuario = "Renan Saggio";
            var lanceUsuario = 400;

            leiloes.Visita();
            var lances = leiloes.Detalhes(1);
            lances.Lance(usuario, lanceUsuario);
            System.Threading.Thread.Sleep(1200);

            Assert.IsTrue(lances.ExisteNaListagem(usuario, lanceUsuario));
        }
    }
}
