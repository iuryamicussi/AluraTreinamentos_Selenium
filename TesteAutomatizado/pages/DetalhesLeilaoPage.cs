using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteAutomatizado.pages
{
    
    public class DetalhesLeilaoPage
    {
        IWebDriver driver;
        public DetalhesLeilaoPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Lance(string usuario, double valor)
        {
            var cbUsuario = new SelectElement(driver.FindElement(By.Name("lance.usuario.id")));
            IWebElement txtValor = driver.FindElement(By.Name("lance.valor"));

            cbUsuario.SelectByText(usuario);
            txtValor.SendKeys(valor.ToString());

            driver.FindElement(By.Id("btnDarLance")).Click();
        }

        public bool ExisteNaListagem(string usuario, double valor)
        {
            bool existe = new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => d.FindElement(By.Id("lancesDados")).Text.Contains(usuario));

            if (existe)
            {
                return driver.PageSource.Contains(valor.ToString());
            }

            return false;
        }
    }
}
