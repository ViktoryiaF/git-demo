using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pageObject_tpo_lab6.PageObjects
{
    class SearchingTrainResultsPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public SearchingTrainResultsPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//p[text()='Время выезда/приезда: местное']")]
        public IWebElement SearchWithAllFieldsAreFullResult { get; set; }



        public SearchingTrainResultsPage Search()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//p[text()='Время выезда/приезда: местное']"))).Click();
            return new SearchingTrainResultsPage(driver);
        }
    }
}
