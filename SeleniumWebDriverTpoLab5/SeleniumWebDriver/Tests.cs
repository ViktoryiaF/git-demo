using System;
using System.Threading;
using NUnit.Framework;
using SeleniumWebDriver;

namespace Tests
{
    public class Tests:TestBase
    {
        private const string ErrorTextForEmptyString =
            "Это поле необходимо заполнить.";

       
        //        Тест 1: найти поезда из минска на послезавтра без указания точки прибытия

        //Шаги : 
        //1. Зайти на сайт https://tickets.by/gd
        //2. Заполнить в форме поиска поле "Откуда" - указать город отправления поезда(Минск)
        //3. Заполнить в форме поиска поле "Дата" - указать дату отправления(послезавтра)
        //4. Нажать кнопку "найти" в форме поиска

        [Test]
        public void SearchWithoutEnteringTheCityOfArrival()
        {
            #region TestData

            const string departureCityText = "Минск";


            #endregion

            var departureCity = GetWebElementById("from_name_as");
            departureCity.SendKeys(departureCityText);
            var departureDate = GetWebElementById("departure_date");
            departureDate.Click();
            var departureDateChoose = GetWebElementByClassName("ui-datepicker-week-end.day_td.date_1572037200000");
            departureDateChoose.Click();
            var searchButton = GetWebElementByClassName("search__form-button.button");
            searchButton.Click();
            var errorMessage = GetWebElementByXPath("//li[@class = 'error']");
            string error = errorMessage.Text;
            Assert.AreEqual(ErrorTextForEmptyString, error);
        }



        //Ожидаемый результат:
        // Поле "Куда" подсвечено красным, под данным полем имеется сообщение об ошибке: "Это поле необходимо заполнить".

        //        Тест 2: перейти к выбору поезда из Минска в Москву на послезавтра, заполнив все поля в форме поиска

        //   Шаги:
        //1. Зайти на сайт https://tickets.by/gd
        //2. Заполнить в форме поиска поле "Откуда"- указать город отправления поезда(Минск)
        //3. Заполнить в форме поиска поле "Куда" - указать город прибытия поезда(Москва)
        //4. Заполнить в форме поиска поле "Дата" - указать дату отправления(послезавтра)
        //5. Нажать кнопку "найти" в форме поиска

        //Ожидаемый результат:
        // Открывается страница "Выбор поезда"(поле будет выделено серым), 
        // ниже буден написан маршрут Минск ->  Москва(дд.мм.гггг), 
        // ещё ниже - таблица со списком поездов, либо запись об их отсутствии.


        [Test]
        public void SearchWithAllFieldsAreFull()
        {
            #region TestData

            const string departureCityText = "Минск";
            const string arrivalCityText = "Москва" ;

           
            #endregion

            var departureCity = GetWebElementById("from_name_as");
            departureCity.SendKeys(departureCityText);
            var arrivalCity = GetWebElementById("to_name");
            arrivalCity.SendKeys(arrivalCityText);
            var departureDate = GetWebElementById("departure_date");
            departureDate.Click();
            var departureDateChoose = GetWebElementByClassName("ui-datepicker-week-end.day_td.date_1572037200000");
            departureDateChoose.Click();
            var searchButton = GetWebElementByClassName("search__form-button.button");
            searchButton.Click();
        }

       
    }
}