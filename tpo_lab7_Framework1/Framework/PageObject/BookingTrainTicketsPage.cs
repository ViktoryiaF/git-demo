using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Framework.Models;
using Framework.Tests;
using Framework.Service;

namespace Framework.PageObject
{
    class BookingTrainTicketsPage
    {
        private IWebDriver driver;
        static DateTime currentDate = DateTime.Today;
        static DateTime prevDate = currentDate.AddDays(-2);
        static DateTime futureDate = currentDate.AddDays(2);


        [FindsBy(How = How.XPath, Using = "//a[@data-action='link-header_login']")]
        private IWebElement LoginButton { get; set; }
      
        [FindsBy(How = How.XPath, Using = "//a[@data-uil='registration']")]
        private IWebElement RegisterButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//samp[@for='email_register']")]
        private IWebElement UserExistsError { get; set; }
        [FindsBy(How = How.Id, Using = "first_name")]
        private IWebElement FirstName { get; set; }
        [FindsBy(How = How.Id, Using = "last_name")]
        private IWebElement LastName { get; set; }
        [FindsBy(How = How.Id, Using = "email_register")]
        private IWebElement Email { get; set; }
        [FindsBy(How = How.Id, Using = "pass_register")]
        private IWebElement Password { get; set; }
        [FindsBy(How = How.Id, Using = "phone_number_register")]
        private IWebElement PhoneNumber { get; set; }
        [FindsBy(How = How.ClassName, Using = "btn_reg")]
        private IWebElement SubmitRegistration { get; set; }

        [FindsBy(How = How.Id, Using = "to_name")]
        private IWebElement arrivalCity { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[@class= 'ui-menu-item'][1]")]
        private IWebElement chooseArrivalCity { get; set; }

        [FindsBy(How = How.Id, Using = "ui-datepicker-div")]
        private IWebElement departureDate { get; set; }
        [FindsBy(How = How.ClassName, Using = "form-item--date")]
        private IWebElement departureDateButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Найти']")]
        private IWebElement searchButton { get; set; }

        [FindsBy(How = How.Id, Using = "ui-datepicker-div")]
        private IWebElement ddpicker { get; set; }
        [FindsBy(How = How.XPath, Using = "table[@class = 'ui-datepicker-calendar']")]
        public IWebElement dataPicker;

        [FindsBy(How = How.TagName, Using = "tbody")]
        public IWebElement tableBody;


        [FindsBy(How = How.XPath, Using = "//samp[@class = 'error']")]
        public IWebElement errorMessage { get; set; }
        [FindsBy(How = How.ClassName, Using = "ui-datepicker-unselectable ui-state-disabled day_td date")]
        public IWebElement DayBeforeToday { get; set; }

        private By getDateXPath(int month, int day)
        {
            return By.XPath($"//td[@data-month='{month}']/a[text()='{day}']");
        }
        public BookingTrainTicketsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }


        public BookingTrainTicketsPage GoToPage(string pageURL)
        {
            driver.Navigate().GoToUrl(pageURL);
            return this;
        }

        public SearchingTrainResultsPage GoToSearchingTrainResultsPage()
        {
            searchButton.Click();
            return new SearchingTrainResultsPage(driver);
        }

        public bool IsPrevDataClickable()
        {
            int month = prevDate.Month;
            int day = prevDate.Day;
            var prevDataXPath = getDateXPath(month, day);
            var data = ddpicker.FindElement(prevDataXPath);
            return !data.Enabled;
        }
        public BookingTrainTicketsPage InputArrivalCity(Route route)
        {
            arrivalCity.SendKeys(route.ArrivalCity);
            Waiter.WaitForAjax(driver);
            chooseArrivalCity.Click();
            return this;
        }

        public BookingTrainTicketsPage InputDepartureDate()
        {
            departureDate.Click();
            int month = futureDate.Month;
            int day = futureDate.Day;
            var futureDataXPath = getDateXPath(month, day);
            var data = ddpicker.FindElement(futureDataXPath);
            data.Click();

            return this;
        }
        public BookingTrainTicketsPage InputDepartureDateWithoutCountry()
        {
            departureDateButton.Click();
            return this;
        }
        public BookingTrainTicketsPage NoInputArrivalCity()
        {
            searchButton.Click();
            return this;
        }

        public BookingTrainTicketsPage Login()
        {
            LoginButton.Click();
            return this;
        }
        public BookingTrainTicketsPage Register()
        {
            Waiter.WaitForAjax(driver);
            RegisterButton.Click();
            return this;
        }
        public BookingTrainTicketsPage InputUserData(User user)
        {
            Waiter.WaitForAjax(driver);
            FirstName.SendKeys(user.FirstName);
            LastName.SendKeys(user.LastName);
            Email.SendKeys(user.Email);
            Password.SendKeys(user.Password);
            PhoneNumber.SendKeys(user.PhoneNumber);
            return this;
        }
        public BookingTrainTicketsPage SubmitReg()
        {
            Waiter.WaitForAjax(driver);
            SubmitRegistration.Click();
            return this;
        }


        public bool IsUserExists()
        {
            Waiter.WaitForAjax(driver);
            return UserExistsError.Displayed;
        }
    }
}
