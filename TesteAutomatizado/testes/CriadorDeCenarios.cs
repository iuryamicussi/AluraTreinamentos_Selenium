using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteAutomatizado.pages;

namespace TesteAutomatizado.testes
{
    public class CriadorDeCenarios
    {

        private IWebDriver driver;

        public CriadorDeCenarios(IWebDriver driver)
        {
            this.driver = driver;
        }

        public CriadorDeCenarios umUsuario(string nome, string email)
        {
            UsuariosPage usuarios = new UsuariosPage(driver);
            usuarios.Visita();
            usuarios.Novo().Cadastra(nome, email);
            System.Threading.Thread.Sleep(1200);
            return this;
        }

        public CriadorDeCenarios umLeilao(string usuario,
                    string produto,
                    double valor,
                    bool usado)
        {
            LeilaoPage leiloes = new LeilaoPage(driver);
            leiloes.Visita();
            leiloes.Novo().Cadastra(produto, valor, usuario, usado);
            System.Threading.Thread.Sleep(1200);
            return this;
        }

    }
}
