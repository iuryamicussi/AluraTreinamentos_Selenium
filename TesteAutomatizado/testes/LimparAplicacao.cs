using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteAutomatizado.testes
{
    public class LimparAplicacao
    {
        public void LimparBanco(IWebDriver driver) => 
            driver.Navigate().GoToUrl("http://localhost:8080/apenas-teste/limpa");
    }
}
