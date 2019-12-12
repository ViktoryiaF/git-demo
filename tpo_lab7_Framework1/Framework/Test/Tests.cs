using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using Framework.PageObject;
using Framework.Service;
using Framework.Models;
using Framework.Driver;
using Framework.Tests;

namespace Framework.Test
{
    class Tests: CommonConditions
    {
        const string ErrorTextForSearchWithAllFieldsAreFullResult =
            "Время выезда/приезда: местное";

        const string ErrorTextForSearchWithoutEnteringTheCityOfArrival =
            "Это поле необходимо заполнить";

        const string StartPage = "https://tickets.by/gd";

        [Test]
        public void SearchWithAllFieldsAreFull()
        {
            BookingTrainTicketsPage home = new BookingTrainTicketsPage(Driver)
                .GoToPage(StartPage)
                .InputArrivalCity()
                .InputDepartureDate()
                .GoToPageWhithSerchingResultsPage();
            SearchingTrainResultsPage search = new SearchingTrainResultsPage(Driver)
                .Search();
            Assert.AreEqual(ErrorTextForSearchWithAllFieldsAreFullResult, search.SearchWithAllFieldsAreFullResult.Text);

        }

        [Test]
        public void SearchWithoutEnteringTheCityOfArrival()
        {
            BookingTrainTicketsPage home = new BookingTrainTicketsPage(Driver)
                .GoToPage(StartPage)
                .InputDepartureDate()
                .NoInputArrivalCity();
            Assert.AreEqual(ErrorTextForSearchWithoutEnteringTheCityOfArrival, home.errorMessage.Text);

        }

    }
}
