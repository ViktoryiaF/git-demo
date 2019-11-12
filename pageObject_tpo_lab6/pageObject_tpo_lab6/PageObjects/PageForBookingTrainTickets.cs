using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pageObject_tpo_lab6.PageObjects
{
    class PageForBookingTrainTickets
    {
        private IWebDriver driver;
        static  DateTime currentDate = DateTime.Now;
        private static  string dayAfterTomorrowDate = (currentDate.AddDays(2)).Day.ToString();
        private static  string monthOfDayAfterTomorrow = (currentDate.AddMonths(-1)).Month.ToString();
        public PageForBookingTrainTickets(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            
        }

        

        [FindsBy(How = How.Id, Using = "to_name")]
        private readonly IWebElement arrivalCity;


        [FindsBy(How = How.XPath, Using = "//strong[text() ='Москва']")]
        private readonly IWebElement chooseArrivalCity;

        [FindsBy(How = How.ClassName, Using = "ui-datepicker-trigger")]
        private readonly IWebElement departureDate;


        [FindsBy(How = How.XPath, Using = "//td[@data-month=" + monthOfDayAfterTomorrow + "]/descendant-or-self::a[text() = " + dayAfterTomorrowDate + "]")]
        private readonly IWebElement departureDateChoose;


        [FindsBy(How = How.XPath, Using = "//input[@value='Найти']")]
        private readonly IWebElement searchButton;

        [FindsBy(How = How.XPath, Using = "//samp[@class = 'error']")]
        public  IWebElement errorMessage;

      
        public void goToPage()
        {
            driver.Navigate().GoToUrl("https://tickets.by/gd");
        }

        public PageWhithSerchingResults GoToPageWhithSerchingResultsPage()
        {
            searchButton.Click();
            return new PageWhithSerchingResults(driver);
        }

        public PageForBookingTrainTickets InputArrivalCity(string arrivalCityInput)
        {
            arrivalCity.SendKeys(arrivalCityInput);
            chooseArrivalCity.Click();
            return this;
        }

        public PageForBookingTrainTickets InputDepartureDate()
        {
            departureDate.Click();
            departureDateChoose.Click();
            return this;
        }

        public PageForBookingTrainTickets NoInputArrivalCity()
        {
            searchButton.Click();
            return this;
        }

    }
}
