using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using TesteAutomatizado.pages;

namespace TesteAutomatizado.testes
{
    [TestFixture]
    public class UsuarioSystemTest
    {
        private UsuariosPage usuarios;
        private IWebDriver driver;

        [SetUp]
        public void SetUpFixture()
        {
            driver = new FirefoxDriver(@"C:\Users\user\Source\Repos\TesteAutomatizado\TesteAutomatizado\bin");
            usuarios = new UsuariosPage(driver);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }

        [Test]
        public void DeveCadastrarUmUsuario()
        {
            var nome = "Iury Nunes Amicussi";
            var email = "iury@multiplice.com.br";

            usuarios.Visita();
            usuarios.Novo().Cadastra(nome, email);

            Assert.IsTrue(usuarios.ExisteNaListagem(nome, email));
        }

        [Test]
        public void DeveBloquearEInformarODevidoPreenchimentoDoCampoUsuarioCasoVazio()
        {
            driver.Navigate().GoToUrl("http://localhost:8080/usuarios/new");

            IWebElement campoNome = driver.FindElement(By.Name("usuario.nome"));
            IWebElement campoEmail = driver.FindElement(By.Name("usuario.email"));
            IWebElement btnSalvar = driver.FindElement(By.Id("btnSalvar"));

            campoNome.SendKeys("");
            campoEmail.SendKeys("axavier@empresa.com.br");

            btnSalvar.Click();

            bool achouMensagemObrigatorio = driver.PageSource.Contains("Nome obrigatorio!");

            Assert.IsTrue(achouMensagemObrigatorio);
        }

        [Test]
        public void DeveBloquearEInformarODevidoPreenchimentoDoCampoUsuarioEEmailCasoVazios()
        {
            driver.Navigate().GoToUrl("http://localhost:8080/usuarios/new");

            driver.FindElement(By.Id("btnSalvar")).Click();

            bool achouMensagemNomeObrigatorio = driver.PageSource.Contains("Nome obrigatorio!");
            bool achouMensagemEmailObrigatorio = driver.PageSource.Contains("E-mail obrigatorio!");

            Assert.IsTrue(achouMensagemNomeObrigatorio);
            Assert.IsTrue(achouMensagemEmailObrigatorio);
        }

        [Test]
        public void DeveAcessarOLinkDeCadastroDeUsuarios()
        {
            driver.Navigate().GoToUrl("http://localhost:8080/usuarios");

            IWebElement linkNovoUsuario = driver.FindElement(By.LinkText("Novo Usuário"));
            linkNovoUsuario.Click();

            IWebElement campoNome = driver.FindElement(By.Name("usuario.nome"));
            IWebElement campoEmail = driver.FindElement(By.Name("usuario.email"));
            IWebElement btnSalvar = driver.FindElement(By.Id("btnSalvar"));

            campoNome.SendKeys("Adriano Xavier");
            campoEmail.SendKeys("axavier@empresa.com.br");

            btnSalvar.Click();

            bool achouNome = driver.PageSource.Contains("Adriano Xavier");
            bool achouEmail = driver.PageSource.Contains("axavier@empresa.com.br");

            Assert.IsTrue(achouNome);
            Assert.IsTrue(achouEmail);
        }
    }
}
