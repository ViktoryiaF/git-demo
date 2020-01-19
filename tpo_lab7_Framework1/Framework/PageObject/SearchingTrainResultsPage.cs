using Framework.Service;
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

        [FindsBy(How = How.XPath, Using = "//a[@data-increment='plus']")]
        public IList<IWebElement> PlusButtons { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@data-increment='minus']")]
        public IList<IWebElement> MinusButtons { get; set; }

        [FindsBy(How = How.ClassName, Using = "add-group__item--input")]
        public IList<IWebElement> PassangersNumber { get; set; }

        [FindsBy(How = How.ClassName, Using = "one_sit")]
        public IList<IWebElement> PlacesToSit { get; set; }

        [FindsBy(How = How.ClassName, Using = "ui-tooltip-content")]
        public IWebElement errorToolTip { get; set; }

        [FindsBy(How = How.ClassName, Using = "js-prebook-btn")]
        public IList<IWebElement> EnterPassengerInfo { get; set; }

        [FindsBy(How = How.ClassName, Using = "preloader_light")]
        public IWebElement Preloader { get; set; }

        [FindsBy(How = How.ClassName, Using = "popup-info__text")]
        public IWebElement ErrorPopup { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Продолжить']")]
        public IWebElement BuyButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//samp[@class='error']")]
        public IList<IWebElement> ErrorField { get; set; }

        [FindsBy(How = How.ClassName, Using = "iCheck-helper")]
        public IList<IWebElement> SexRadioButtons { get; set; }


        //iCheck-helper


        public SearchingTrainResultsPage Search()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//p[text()='Время выезда/приезда: местное']"))).Click();
            return new SearchingTrainResultsPage(driver);
        }

        public SearchingTrainResultsPage ChooseTrainClick()
        {
            Waiter.WaitForAjax(driver);
            ChooseTrain.Click();
            return this;
        }

        public SearchingTrainResultsPage ChildTillFivePlusClick()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(e => e.FindElement(By.ClassName("preloader_light")).GetAttribute("style") == "display: none;");
            Waiter.WaitForAjax(driver);
            PlusButtons[2].Click();
            return this;
        }

        public SearchingTrainResultsPage ChildPlusClick()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(e => e.FindElement(By.ClassName("preloader_light")).GetAttribute("style") == "display: none;");
            Waiter.WaitForAjax(driver);
            PlusButtons[1].Click();
            return this;
        }

        public SearchingTrainResultsPage AdultMinusClick()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            .Until(e => e.FindElement(By.ClassName("preloader_light")).GetAttribute("style") == "display: none;");
            Waiter.WaitForAjax(driver);

            MinusButtons[0].Click();
            return this;
        }

        public SearchingTrainResultsPage AdultPlusClick(int n)
        {
            for (int i = 0; i < n; i++)
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(10))
               .Until(e => e.FindElement(By.ClassName("preloader_light")).GetAttribute("style") == "display: none;");
                Waiter.WaitForAjax(driver);
                PlusButtons[0].Click();
            }
            return this;
        }
        public bool check()
        {
            var value = PassangersNumber.First();
            var compareResult = value.GetAttribute("value") == "1";
            return compareResult;
        }
        public SearchingTrainResultsPage PlaceToSitClick(int numberOfSits)
        {
            for (int i = 0; i < numberOfSits; i++)
            {
                foreach (var sit in PlacesToSit)
                {
                    if (!sit.GetAttribute("class").Contains("occupied") && !sit.GetAttribute("class").Contains("checked"))
                    {
                        new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                            .Until(e => e.FindElement(By.ClassName("preloader_light")).GetAttribute("style") == "display: none;");
                        Waiter.WaitForAjax(driver);
                        sit.Click();
                        break;
                    }
                }
            }
            return this;
        }

        public SearchingTrainResultsPage EnterPassangerInfoClick()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
              .Until(e => e.FindElement(By.ClassName("preloader_light")).GetAttribute("style") == "display: none;");
            Waiter.WaitForAjax(driver);
            EnterPassengerInfo[1].Click();
            return this;
        }

        public SearchingTrainResultsPage BuyButtonClick()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            .Until(e => e.FindElement(By.ClassName("preloader_light")).GetAttribute("style") == "display: none;");
            Waiter.WaitForAjax(driver);

            BuyButton.Click();
            return this;
        }

       
    }
}