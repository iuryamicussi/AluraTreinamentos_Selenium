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
    public class LeilaoSystemTest
    {
        private LeilaoPage leilao;
        private IWebDriver driver;
        private string usuarioTestePadrao = "Renan Saggio";

        [SetUp]
        public void Inicializa()
        {
            driver = new FirefoxDriver(@"C:\Users\user\Source\Repos\TesteAutomatizado\TesteAutomatizado\bin");
            new LimparAplicacao().LimparBanco(driver);
            this.leilao = new LeilaoPage(driver);

            var usuario = new UsuariosPage(driver);
            usuario.Visita();
            if (!usuario.ExisteNaListagem(usuarioTestePadrao, "renan@caelum.com.br"))
            {
                usuario.Novo().Cadastra(usuarioTestePadrao, "renan@caelum.com.br");
                System.Threading.Thread.Sleep(1200);
            }
        }

        [TearDown]
        public void Finaliza()
        {
            driver.Close();
        }

        [Test]
        public void DeveCadastrarLeilao()
        {
            leilao.Visita();

            leilao.Novo().Cadastra("Geladeira", 123, usuarioTestePadrao, true);
            System.Threading.Thread.Sleep(1200);
            Assert.IsTrue(leilao.ExisteNaListagem("Geladeira", 123, usuarioTestePadrao, true));
        }

        [Test]
        public void DeveBloquearInsercaoLeilaoSemNomeItem()
        {
            leilao.Visita();
            var paginaLeilaoNovo = leilao.Novo();
            paginaLeilaoNovo.Cadastra("", 123, usuarioTestePadrao, false);
            System.Threading.Thread.Sleep(1200);
            Assert.IsTrue(paginaLeilaoNovo.ExisteNaPagina("Nome obrigatorio!")); 
        }

        [Test]
        public void DeveBloquearInsercaoLeilaoSemValor()
        {
            leilao.Visita();
            var paginaLeilaoNovo = leilao.Novo();
            paginaLeilaoNovo.Cadastra("Geladeira", string.Empty , usuarioTestePadrao, false);
            System.Threading.Thread.Sleep(1200);
            Assert.IsTrue(paginaLeilaoNovo.ExisteNaPagina("Valor inicial deve ser maior que zero!")); 
        }

        [Test]
        public void DeveBloquearInsercaoLeilaoSemNomeEComValorZerado()
        {
            leilao.Visita();
            var paginaLeilaoNovo = leilao.Novo();
            paginaLeilaoNovo.Cadastra(string.Empty, 0, usuarioTestePadrao, false);
            System.Threading.Thread.Sleep(1200);
            Assert.IsTrue(paginaLeilaoNovo.ExisteNaPagina("Nome obrigatorio!"));
            Assert.IsTrue(paginaLeilaoNovo.ExisteNaPagina("Valor inicial deve ser maior que zero!"));
        }
    }
}
