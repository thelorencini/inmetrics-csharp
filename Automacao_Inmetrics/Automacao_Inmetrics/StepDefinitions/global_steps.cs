using Automacao_Inmetrics.Pages;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using BoDi;
using System;


namespace Automacao_Inmetrics.StepDefinitions
{

    [Binding]
    public class Global_Steps
    {
        private readonly RemoteWebDriver driver;
        readonly Home_Page home;
        readonly Gupy_Page gupy;

        public Global_Steps(RemoteWebDriver _driver)
        {
            this.driver = _driver;
            home = new Home_Page(driver);
            gupy = new Gupy_Page(driver);
        }


        [Given(@"que eu acesso o site da Inmetrics")]
        public void DadoQueEuAcessoOSiteDaInmetrics()
        {
            home.validaSite();
        }

        [Given(@"desejo visualizar as opções de carreira")]
        public void DadoDesejoVisualizarAsOpcoesDeCarreira()
        {
            home.selecionarCarreiras();
        }

        [When(@"eu selecionar o button para conferir vagas disponiveis")]
        public void QuandoEuSelecionarOButtonParaConferirVagasDisponiveis()
        {
            home.confiraVagas();
        }

        [Then(@"devo ser direcionado para pagina de oportunidades")]
        public void EntaoDevoSerDirecionadoParaPaginaDeOportunidades()
        {
            gupy.validaAcesso();
        }


    }
}
