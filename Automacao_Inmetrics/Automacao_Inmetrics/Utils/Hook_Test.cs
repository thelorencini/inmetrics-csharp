using System;
using System.Configuration;
using Automacao_Inmetrics.Utils;
using BoDi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;

namespace Automacao_Inmetrics.Utils
{

    public class Hook_Test
    {

        private static int inc { get; set; }
        private readonly IObjectContainer container;

        public Hook_Test(IObjectContainer _container)
        {
            this.container = _container;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            RemoterWebDriver.initDriver("Chrome").Url = "https://www.inmetrics.com.br";
            container.RegisterInstanceAs<RemoteWebDriver>(RemoterWebDriver.GetDriver());

        }

        [BeforeStep]
        public static void BeforeStep()
        {
            Base bs = new Base(RemoterWebDriver.GetDriver());
            bs.WaitForPageLoading();
            bs.ReturnToTheTopPage();

        }


        [AfterScenario]
        public static void DisposeDriver()
        {
            RemoterWebDriver.RemoveCurrentThread();
        }
    }
}
