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
            new LimparAplicacao().LimparBanco(driver);
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
            System.Threading.Thread.Sleep(1200);
            var result = usuarios.ExisteNaListagem(nome, email);
            Assert.IsTrue(result);
        }

        [Test]
        public void DeveBloquearEInformarODevidoPreenchimentoDoCampoUsuarioCasoVazio()
        {
            usuarios.Visita();

            var paginaNovoUsuario = usuarios.Novo();
            paginaNovoUsuario.Cadastra("", "axavier@empresa.com.br");
            System.Threading.Thread.Sleep(1200);
            Assert.IsTrue(paginaNovoUsuario.ExisteNaPagina("Nome obrigatorio!"));
        }

        [Test]
        public void DeveBloquearEInformarODevidoPreenchimentoDoCampoUsuarioEEmailCasoVazios()
        {
            usuarios.Visita();

            var paginaNovoUsuario = usuarios.Novo();
            paginaNovoUsuario.Cadastra("", "");
            System.Threading.Thread.Sleep(1200);
            Assert.IsTrue(paginaNovoUsuario.ExisteNaPagina("Nome obrigatorio!"));
            Assert.IsTrue(paginaNovoUsuario.ExisteNaPagina("E-mail obrigatorio!"));
        }

        [Test]
        public void DeveCadastrarUsuarioEExcluiloDaListaDeUsuarios()
        {
            var nome = "Iury Nunes Amicussi";
            var email = "iury@multiplice.com.br";

            usuarios.Visita();
            usuarios.Novo().Cadastra(nome, email);
            System.Threading.Thread.Sleep(1200);
            var result = usuarios.ExisteNaListagem(nome, email);
            Assert.IsTrue(result);

            usuarios.Excluir(1);
            System.Threading.Thread.Sleep(1200);
            result = usuarios.ExisteNaListagem(nome, email);
            Assert.IsFalse(result);
        }

        [Test]
        public void DeveCadastrarUsuarioEEditalo()
        {
            var nome = "Iury Nunes Amicussi";
            var email = "iury@multiplice.com.br";

            usuarios.Visita();
            usuarios.Novo().Cadastra(nome, email);
            System.Threading.Thread.Sleep(1200);
            Assert.IsTrue(usuarios.ExisteNaListagem(nome, email));

            usuarios.Editar(1).Alterar("pikachu","pikachu@pokemon.com");
            System.Threading.Thread.Sleep(1200);
            Assert.IsTrue(usuarios.ExisteNaListagem("pikachu", "pikachu@pokemon.com"));
            Assert.IsFalse(usuarios.ExisteNaListagem(nome, email));
        }
    }
}
