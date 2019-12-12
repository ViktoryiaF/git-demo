using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using pageObject_tpo_lab6.PageObjects;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pageObject_tpo_lab6
{
    public class TestClass
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        const string ErrorTextForSearchWithAllFieldsAreFullResult =
            "Время выезда/приезда: местное";

        const string ErrorTextForSearchWithoutEnteringTheCityOfArrival =
            "Это поле необходимо заполнить";

        const string StartPage = "https://tickets.by/gd";

        [Test]
        public void SearchWithAllFieldsAreFull()
        {
            BookingTrainTicketsPage home = new BookingTrainTicketsPage(driver)
                .GoToPage(StartPage)
                .InputArrivalCity()
                .InputDepartureDate()
                .GoToPageWhithSerchingResultsPage();
            SearchingTrainResultsPage search = new SearchingTrainResultsPage(driver)
                .Search();
            Assert.AreEqual(ErrorTextForSearchWithAllFieldsAreFullResult, search.SearchWithAllFieldsAreFullResult.Text);

        }

        [Test]
        public void SearchWithoutEnteringTheCityOfArrival()
        {
            BookingTrainTicketsPage home = new BookingTrainTicketsPage(driver)
                .GoToPage(StartPage)
                .InputDepartureDate()
                .NoInputArrivalCity();
            Assert.AreEqual(ErrorTextForSearchWithoutEnteringTheCityOfArrival, home.errorMessage.Text);

        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}