using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

namespace TesteAutomatizado
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver (@"C:\Users\user\Source\Repos\TesteAutomatizado\TesteAutomatizado\bin");
            driver.Navigate().GoToUrl("http://www.google.com.br");

            IWebElement campoDeTexto = driver.FindElement(By.Name("q"));
            campoDeTexto.SendKeys("Caelum");

            campoDeTexto.Submit();
            //driver.Close();
        }
    }
}
