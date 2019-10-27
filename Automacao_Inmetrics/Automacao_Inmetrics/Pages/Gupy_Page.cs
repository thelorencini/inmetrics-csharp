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
    public class Gupy_Page : Base
    {

        private readonly RemoteWebDriver driver;
        public Gupy_Page(RemoteWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }


        public void validaAcesso()
        {
            var erroPage = ProcurarElemento(GupyElements.erroPagina);
            if(erroPage == null)
            {
                if (driver.Url.Contains("gupy"))
                {
                    var vagas = ProcurarElemento(GupyElements.vagasGupy);
                    if (vagas == null && !vagas.Displayed)
                    {
                        Assert.Fail("Erro ao carregar página");
                    }
                }
                else
                {
                    Assert.Fail("Erro ao acessar página de vagas Gupy");
                }
            }
            else
            {
                Assert.Fail("Erro ao acessar página de vagas Gupy");
            }
        }

    }
}
