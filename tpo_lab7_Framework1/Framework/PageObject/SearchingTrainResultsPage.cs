using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Tests
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

        [FindsBy(How = How.ClassName, Using = "choose")]
        public IWebElement ChooseTrain { get; set; }
        [FindsBy(How = How.XPath, Using = "a//[@data-increment='plus'][2]")]
        public IWebElement ChildPlus { get; set; }
        [FindsBy(How = How.XPath, Using = "a//[@data-increment='minus'][1]")]
        public IWebElement AdultMinus { get; set; }
        [FindsBy(How = How.XPath, Using = "a//[@data-increment='plus'][1]")]
        public IWebElement AdultPlus { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@class = 'add-group__item add-group__item--input'][0]")]
        public IWebElement MinAdults { get; set; }
        [FindsBy(How = How.XPath, Using = "a//[@class='one-seat one_sit top tr'][1]")]
        public IWebElement FirstPlaceToSit { get; set; }
        [FindsBy(How = How.XPath, Using = "a//[@class='one-seat one_sit top tr'][2]")]
        public IWebElement SecondPlaceToSit { get; set; }

        [FindsBy(How = How.ClassName, Using = "ui-tooltip-content")]
        public IWebElement errorToolTip { get; set; }

        [FindsBy(How = How.ClassName, Using = "button js-prebook-btn")]
        public IWebElement EnterPassengerInfo { get; set; }


        public SearchingTrainResultsPage Search()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//p[text()='Время выезда/приезда: местное']"))).Click();
            return new SearchingTrainResultsPage(driver);
        }

        public SearchingTrainResultsPage ChooseTrainClick()
        {
            ChooseTrain.Click();
            return this;
        }

        public SearchingTrainResultsPage ChildPlusClick()
        {
            ChildPlus.Click();
            return this;
        }

        public SearchingTrainResultsPage AdultMinusClick()
        {
            AdultMinus.Click();
            return this;
        }

        public SearchingTrainResultsPage AdultPlusClick(int n)
        {
            for (int i = 0; i < n; i++)
            {
                AdultPlus.Click();
            }
            return this;
        }

        public SearchingTrainResultsPage PlaceToSitClick(int numberOfSits)
        {
            if (numberOfSits == 1)
            {
                FirstPlaceToSit.Click();
            }
            else
            {
                FirstPlaceToSit.Click();
                SecondPlaceToSit.Click();
            }


            return this;
        }

        public SearchingTrainResultsPage EnterPassangerInfoClick()
        {
            EnterPassengerInfo.Click();
            return this;
        }

    }
}