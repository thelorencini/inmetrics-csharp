using System;
using Automacao_Inmetrics.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;

namespace Automacao_Inmetrics.Utils
{
    [Binding]
    public class Hook_Test
    {
       

        [BeforeScenario]
        public void BeforeScenario()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.inmetrics.com.br/");
            driver.Manage().Window.Maximize();

        }

        [AfterScenario]
        public void afterScenario()
        {
            Base.EndSession();
        }
    }
}
