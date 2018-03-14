using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;

namespace TesteAutomatizado.pages
{
    public class AlteraUsuarioPage
    {
        private IWebDriver driver;

        private IWebElement campoNome;
        private IWebElement campoEmail;

        public AlteraUsuarioPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Alterar(string nome, string email)
        {
            campoNome = driver.FindElement(By.Name("usuario.nome"));
            campoEmail = driver.FindElement(By.Name("usuario.email"));

            campoNome.Clear();
            campoEmail.Clear();

            campoNome.SendKeys(nome);
            campoEmail.SendKeys(email);

            campoNome.Submit();
        }
    }
}
