using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pageObject_tpo_lab6.PageObjects
{
    class BookingTrainTicketsPage
    {
        private IWebDriver driver;
        public static DateTime currentDate = DateTime.Today;
        string stringDate = currentDate.AddDays(2).Day.ToString();


        [FindsBy(How = How.XPath, Using = "table[@class = 'ui-datepicker-calendar']")]
        public IWebElement dataPicker;

        [FindsBy(How = How.TagName, Using = "tbody")]
        public IWebElement tableBody;

        [FindsBy(How = How.Id, Using = "to_name")]
        private IWebElement arrivalCity { get; set; }

        [FindsBy(How = How.Id, Using = "ui-id-22")]
        private IWebElement chooseArrivalCity { get; set; }

        [FindsBy(How = How.Id, Using = "ui-datepicker-div")]
        private IWebElement departureDate { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Найти']")]
        private IWebElement searchButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//samp[@class = 'error']")]
        public IWebElement errorMessage { get; set; }

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

        public BookingTrainTicketsPage InputArrivalCity(string arrivalCityInput)
        {
            arrivalCity.SendKeys(arrivalCityInput);
            chooseArrivalCity.Click();
            return this;
        }

        public BookingTrainTicketsPage InputDepartureDate()
        {
            departureDate.Click();
            var rows = tableBody.FindElements(By.TagName("tr"));
            foreach (var row in rows)
            {
                var cells = row.FindElements(By.TagName("td"));
                foreach (var cell in cells)
                {
                    var daysInDataPicker = cell.FindElement(By.TagName("a")).GetAttribute("text");
                    if (daysInDataPicker == stringDate)
                    {
                        cell.Click();
                    }
                }
            }
            return this;
        }

        public BookingTrainTicketsPage NoInputArrivalCity()
        {
            searchButton.Click();
            return this;
        }

    }
}

