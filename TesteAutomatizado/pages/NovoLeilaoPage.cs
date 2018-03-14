using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteAutomatizado.pages
{
    public class NovoLeilaoPage
    {
        IWebDriver driver;

        public NovoLeilaoPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Cadastra(string nomeItem,double valorItem, string usuario, bool usado)
        {
            IWebElement txtNome = driver.FindElement(By.Name("leilao.nome"));
            IWebElement txtValor = driver.FindElement(By.Name("leilao.valorInicial"));

            txtNome.SendKeys(nomeItem);
            txtValor.SendKeys(valorItem.ToString());

            var cbUsuario = new SelectElement(driver.FindElement(By.Name("leilao.usuario.id")));
            cbUsuario.SelectByText(usuario);

            if(usado)
                driver.FindElement(By.Name("leilao.usado")).Click();

            txtNome.Submit();
        }

        public void Cadastra(string nomeItem, string valorItem, string usuario, bool usado)
        {
            IWebElement txtNome = driver.FindElement(By.Name("leilao.nome"));
            IWebElement txtValor = driver.FindElement(By.Name("leilao.valorInicial"));

            txtNome.SendKeys(nomeItem);
            txtValor.SendKeys(valorItem);

            var cbUsuario = new SelectElement(driver.FindElement(By.Name("leilao.usuario.id")));
            cbUsuario.SelectByText(usuario);

            if (usado)
                driver.FindElement(By.Name("leilao.usado")).Click();

            txtNome.Submit();
        }

        public bool ExisteNaPagina(string conteudo) => driver.PageSource.Contains(conteudo);
    }
}
