using BoDi;
using Gherkin.Ast;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using TechTalk.SpecFlow;

namespace Automacao_Inmetrics.Utils
{
    public class RemoterWebDriver
    {

        private RemoterWebDriver()
        {
        }

        private const string _browser = "Chrome";
        private static readonly object _synclock = new object();

        public static RemoteWebDriver initDriver(string _browser)
        {

            lock (_synclock)
            {
                try
                {

                    var dirDrivers = Path.GetFullPath(@"..\") + @"Automacao_Inmetrics\Drivers";
                    _driver = null;
                    switch (_browser)
                    {
                        case "Firefox":
                            _driver = new FirefoxDriver(dirDrivers);
                            break;
                        case "Chrome":
                            var options = new ChromeOptions();
                            options.AddArgument("no-sandbox");
                            _driver = new ChromeDriver(options);

                            break;
                        default:
                            _driver = new ChromeDriver();
                            break;
                    }

                    _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(300);
                    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
                    _driver.Manage().Window.Maximize();
                    browser = _browser;
                    return _driver;
                }
                catch(Exception e)
                {
                    if (_driver != null)
                    {
                        _driver.Quit();
                        _driver.Dispose();
                    }
                    return _driver;

                }
            }

        }

        public static void RemoveCurrentThread()
        {
            if (_driver != null)
            {
                _driver.Close();
                _driver.Quit();
                _driver = null;

            }

        }
        public static RemoteWebDriver GetDriver()
        {
            return _driver;

        }

        [ThreadStatic]
        public static String browser;
        [ThreadStatic]
        public static RemoteWebDriver _driver;

    }
}
