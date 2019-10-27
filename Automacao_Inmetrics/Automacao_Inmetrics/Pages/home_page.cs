using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automacao_Inmetrics.Elements;
using Automacao_Inmetrics.Utils;
using NUnit.Framework;

namespace Automacao_Inmetrics.Pages
{
    public class Home_Page : Base
    {

        private readonly RemoteWebDriver driver;
        public Home_Page(RemoteWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }


        public void selecionarCarreiras()
        {
            try
            {
                clicarElemento(HomeElements.linkCarreiras);
            }
            catch
            {
                Assert.Fail("Link carreias não clicável");
            }
            
        }

        public void validaSite()
        {
            if (driver.Url.Contains("inmetrics"))
            {
                var inicio = ProcurarElemento(HomeElements.rodape);
                if (inicio != null && !inicio.Displayed)
                {
                    Assert.Fail("Erro ao acessar site");
                }
            }
            else
            {
                Assert.Fail("Erro ao acessar site");
            }
            Wait(1000);
        }

        public void confiraVagas()
        {

            //Clicar button dinamico  ::: lorencini
            var btnVagas = ProcurarElementos(HomeElements.btnVagas);
            foreach(var item in btnVagas)
            {
                if (item.Text.Contains("confira nossas vagas"))
                {
                    try
                    {
                        item.Click();
                    }
                    catch
                    {
                        Assert.Fail("Button não clicável");
                    }
                    break;
                }

            }

            //Clicar button xpath composto ::: lorencini

            //clicarElemento(HomeElements.xPathBtnVagas);

            Wait(2500);
        }

    }
}
