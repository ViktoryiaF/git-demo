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
    class Tests : CommonConditions
    {
        const string ErrorTextForSearchWithAllFieldsAreFullResult =
            "Время выезда/приезда: местное";

        const string ErrorTextForSearchWithoutEnteringTheCityOfArrival =
            "Это поле необходимо заполнить";
        const string ErrorTextForCantChooseOneSeatsForOnePasengerWithChilds =
          "Выбрано недостаточное колличество мест";
        const string MinAdultsValue = "1";
        const string MaxAdultsValue = "4";
        const string DayBeforeTodayValue = "20";


        const string StartPage = "https://tickets.by/gd";

        [Test]
        public void SearchWithAllFieldsAreFull()
        {
            var route = RouteCreator.WithAllProperties();
            SearchingTrainResultsPage search = new BookingTrainTicketsPage(Driver)
                .GoToPage(StartPage)
                .InputArrivalCity(route)
                .InputDepartureDate()
                .GoToSearchingTrainResultsPage()
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


        [Test]

        public void SearchWithYsterdayDate()
        {
            var route = RouteCreator.WithAllProperties();
            BookingTrainTicketsPage home = new BookingTrainTicketsPage(Driver)
                .GoToPage(StartPage)
                .InputArrivalCity(route);
            Assert.IsTrue(home.IsPrevDataClickable());

        }


        [Test]
        public void LeaveChildWithoutParents()
        {
            var route = RouteCreator.WithAllProperties();
            SearchingTrainResultsPage search = new BookingTrainTicketsPage(Driver)
                .GoToPage(StartPage)
                .InputArrivalCity(route)
                .InputDepartureDate()
                .GoToSearchingTrainResultsPage()
                .Search()
                .ChooseTrainClick()
                 .ChildPlusClick()
                .AdultMinusClick();

            Assert.AreEqual(MinAdultsValue, search.MinAdults.Text);

        }

        [Test]
        public void NotLeaveSixPassengers()
        {
            var route = RouteCreator.WithAllProperties();
            SearchingTrainResultsPage search = new BookingTrainTicketsPage(Driver)
                .GoToPage(StartPage)
                .InputArrivalCity(route)
                .InputDepartureDate()
                .GoToSearchingTrainResultsPage()
                .Search()
                .ChooseTrainClick()
                .AdultPlusClick(6);

            Assert.AreNotEqual(MaxAdultsValue, search.MinAdults.Text);
        }


        [Test]
        public void CantChooseTwoSeatsForOnePasenger()
        {
            var route = RouteCreator.WithAllProperties();
            var errorMessage = ErrorsCreator.WithAllPropertiesErrors();
            SearchingTrainResultsPage search = new BookingTrainTicketsPage(Driver)
                .GoToPage(StartPage)
                .InputArrivalCity(route)
                .InputDepartureDate()
                .GoToSearchingTrainResultsPage()
                .Search()
                .ChooseTrainClick()
                .AdultPlusClick(1)
                .PlaceToSitClick(2);

            Assert.AreEqual( errorMessage, search.errorToolTip.Text);
        }

        [Test]
        public void CantChooseTwoSeatsForOnePasengerWithChildsTillFive()
        {
            var route = RouteCreator.WithAllProperties();
            var errorMessage = ErrorsCreator.WithAllPropertiesErrors();
            SearchingTrainResultsPage search = new BookingTrainTicketsPage(Driver)
                .GoToPage(StartPage)
                .InputArrivalCity(route)
                .InputDepartureDate()
                .GoToSearchingTrainResultsPage()
                .Search()
                .ChooseTrainClick()
                .AdultPlusClick(1)
                .ChildPlusClick()
                .PlaceToSitClick(2);

            Assert.AreEqual(errorMessage, search.errorToolTip.Text);
        }

        [Test]
        public void CantChooseOneSeatsForOnePasengerWithChilds()
        {
            var route = RouteCreator.WithAllProperties();
            
            SearchingTrainResultsPage search = new BookingTrainTicketsPage(Driver)
                .GoToPage(StartPage)
                .InputArrivalCity(route)
                .InputDepartureDate()
                .GoToSearchingTrainResultsPage()
                .Search()
                .ChooseTrainClick()
                .AdultPlusClick(1)
                .ChildPlusClick()
                .PlaceToSitClick(1)
                .EnterPassangerInfoClick();

            Assert.AreEqual(ErrorTextForCantChooseOneSeatsForOnePasengerWithChilds, search.errorToolTip.Text);
        }
    }
}
