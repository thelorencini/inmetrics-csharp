using OpenQA.Selenium;

namespace Automacao_Inmetrics.Elements
{
    static class HomeElements
    {

        public static readonly By linkCarreiras = By.Id("linkcarreiras");
        public static readonly By btnVagas = By.ClassName("btn");
        public static readonly By rodape = By.Id("bs-example-navbar-collapse-1");
        public static readonly By xPathBtnVagas = By.ClassName("//a[contains(@class, 'btn') and contains(., 'confira nossas vagas')]");

    }
}
