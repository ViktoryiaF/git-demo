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
          "Выбрано недостаточное количество мест";
        const string ErrorTextForNotEnterPasengerData =
          "Укажите пол пассажира";

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
                .InputDepartureDateWithoutCountry()
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
            Assert.IsFalse(home.IsPrevDataClickable());
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
            Assert.IsTrue(search.check());

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
            Assert.AreEqual(MaxAdultsValue, search.PassangersNumber[0].GetAttribute("value"));
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
                .PlaceToSitClick(2);
            Assert.AreEqual(errorMessage.ErrorMessage, search.errorToolTip.Text);
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
                .ChildTillFivePlusClick()
                .PlaceToSitClick(2);

            Assert.AreEqual(errorMessage.ErrorMessage, search.errorToolTip.Text);
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
                .ChildPlusClick()
                .PlaceToSitClick(1)
                .EnterPassangerInfoClick();

            Assert.AreEqual(ErrorTextForCantChooseOneSeatsForOnePasengerWithChilds, search.ErrorPopup.Text);
        }

        [Test]
        public void NotEnterPasengerData()
        {
            var route = RouteCreator.WithAllProperties();

            SearchingTrainResultsPage search = new BookingTrainTicketsPage(Driver)
                .GoToPage(StartPage)
                .InputArrivalCity(route)
                .InputDepartureDate()
                .GoToSearchingTrainResultsPage()
                .Search()
                .ChooseTrainClick()
                .PlaceToSitClick(1)
                .EnterPassangerInfoClick()
                .BuyButtonClick();

            Assert.AreEqual(ErrorTextForNotEnterPasengerData, search.ErrorField[0].Text);
        }

        [Test]
        public void IsUserExists()
        {
            var user = UserCreator.WithAllProperties();

            BookingTrainTicketsPage register = new BookingTrainTicketsPage(Driver)
                .GoToPage(StartPage)
                .Login()
                .Register()
                .InputUserData(user)
                .SubmitReg();

            Assert.IsTrue(register.IsUserExists());
        }
    }
}
