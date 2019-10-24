using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace SeleniumWebDriver
{
   public class TestBase
    {
        public IWebDriver webDriver;

        [SetUp]
        public void OpenBrouserAndGoToTheTestSite()
        {
            
            webDriver = new ChromeDriver("C:\\Users\\Acer\\source\\repos\\SeleniumWebDriverTpoLab5\\SeleniumWebDriver\\bin\\Debug\\netcoreapp2.1\\");
            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            webDriver.Navigate().GoToUrl("https://tickets.by/gd");
        }

        [TearDown]
        public void CloseBrouser()
        {
            webDriver.Quit();
        }

        protected IWebElement GetWebElementById(string Id)
        {
            return webDriver.FindElement(By.Id(Id));
        }
        protected IWebElement GetWebElementByClassName(string className)
        {
            return webDriver.FindElement(By.ClassName(className));
        }
        protected IWebElement GetWebElementByXPath(string xPath)
        {
            return webDriver.FindElement(By.XPath(xPath));
        }
    }
}
