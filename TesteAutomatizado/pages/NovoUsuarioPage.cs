using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;

namespace TesteAutomatizado.pages
{
    public class NovoUsuarioPage
    {
        IWebDriver driver;

        public NovoUsuarioPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Cadastra(string nome, string email)
        {
            IWebElement campoNome= driver.FindElement(By.Name("usuario.nome")); 
            IWebElement campoEmail = driver.FindElement(By.Name("usuario.email"));

            campoNome.SendKeys(nome);
            campoEmail.SendKeys(email);

            campoNome.Submit();
        }
    }
}
