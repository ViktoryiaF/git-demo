using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using pageObject_tpo_lab6.PageObjects;
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

        [Test]
        public void SearchWithAllFieldsAreFull()
        {
            PageForBookingTrainTickets home = new PageForBookingTrainTickets(driver);
            PageWhithSerchingResults search = new PageWhithSerchingResults(driver);
            home.goToPage();
            PageForBookingTrainTickets inputArrivalCity = home.InputArrivalCity("Москва");
            PageForBookingTrainTickets inputDepartureDate = home.InputDepartureDate();
            PageWhithSerchingResults goToPageWhithSerchingResultsPage = home.GoToPageWhithSerchingResultsPage();
            PageWhithSerchingResults serchingResults = search.Search();
            Assert.AreEqual("Время выезда/приезда: местное", search.resultOfSearchWithAllFieldsAreFull.Text);

        }

        [Test]
        public void SearchWithoutEnteringTheCityOfArrival()
        {
            PageForBookingTrainTickets home = new PageForBookingTrainTickets(driver);
            home.goToPage();
            PageForBookingTrainTickets inputDepartureDate = home.InputDepartureDate();
            PageForBookingTrainTickets startSearching = home.NoInputArrivalCity();
            Assert.AreEqual("Это поле необходимо заполнить", home.errorMessage.Text);

        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}