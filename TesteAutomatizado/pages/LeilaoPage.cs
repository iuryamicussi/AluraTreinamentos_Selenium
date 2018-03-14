using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteAutomatizado.pages
{
    public class LeilaoPage
    {
        IWebDriver driver;

        public LeilaoPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Visita() =>
            driver.Navigate().GoToUrl("http://localhost:8080/leiloes");

        public NovoLeilaoPage Novo()
        {
            driver.Navigate().GoToUrl("http://localhost:8080/leiloes/new");
            return new NovoLeilaoPage(driver);
        }

        public bool ExisteNaListagem(string nomeItem,double valorDoItem, string usuario ,bool itemUsado)
        {
            return driver.PageSource.Contains(nomeItem)
                && driver.PageSource.Contains(Convert.ToString(valorDoItem))
                && driver.PageSource.Contains(usuario)
                && driver.PageSource.Contains(itemUsado ? "Sim" : "Não");
        }
    }
}
