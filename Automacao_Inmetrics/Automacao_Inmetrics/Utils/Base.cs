using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace Automacao_Inmetrics.Utils
{
    public class Base
    {
        [ThreadStatic]
        private static RemoteWebDriver driver;

        public Base(RemoteWebDriver _driver)
        {
            driver = _driver;
        }

        public static void EndSession()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }

        public void Wait(int miliseconds, int maxTimeOutSeconds = 60)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 1, maxTimeOutSeconds));
            var delay = new TimeSpan(0, 0, 0, 0, miliseconds);
            var timestamp = DateTime.Now;
            wait.Until(webDriver => (DateTime.Now - timestamp) > delay);
        }

        public void HighlightElement(IWebElement element)
        {
            var jsDriver = (IJavaScriptExecutor)driver;
            string highlightJavascript = @"$(arguments[0]).css({ ""border-width"" : ""1px"", ""border-style"" : ""solid"", ""border-color"" : ""blue"" });";
            jsDriver.ExecuteScript(highlightJavascript, new object[] { element });
        }

        public IWebElement ProcurarElemento(By locator)
        {
            try
            {
                IWebElement elemento = driver.FindElement(locator);
                HighlightElement(elemento);
                return elemento;
            }
            catch (NullReferenceException)
            {
                return null;
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }

        public IList<IWebElement> ProcurarElementos(By locator)
        {
            try
            {
                return driver.FindElements(locator);
            }
            catch (NullReferenceException)
            {
                return null;
            }
            catch (NoSuchElementException)
            {
                return null;
            }

        }

        public void clicarElemento(By locator)
        {
            var elem = ProcurarElemento(locator);
            if (elem != null)
            {
                HighlightElement(elem);
                Wait(2000, 3);
                elem.Click();
            }
            else
            {
                Assert.Fail($@"Elemento: {locator}, não foi localizado!");

            }

        }
    }
}
