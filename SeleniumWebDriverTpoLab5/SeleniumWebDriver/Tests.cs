using System;
using System.Threading;
using NUnit.Framework;
using SeleniumWebDriver;

namespace Tests
{
    public class Tests:TestBase
    {
        private const string ErrorTextForEmptyString =
            "Это поле необходимо заполнить";
        private const string message = "Время выезда/приезда: местное";

        //        Тест 1: найти поезда из минска на послезавтра без указания точки прибытия

        //Шаги : 
        //1. Зайти на сайт https://tickets.by/gd
        //2. Заполнить в форме поиска поле "Откуда" - указать город отправления поезда(Минск)
        //3. Заполнить в форме поиска поле "Дата" - указать дату отправления(послезавтра)
        //4. Нажать кнопку "найти" в форме поиска

        static DateTime currentDate = DateTime.Now;
        public string dayAfterTomorrowDate = (currentDate.AddDays(2)).Day.ToString(); 
        private static string monthOfDayAfterTomorrow = (currentDate.AddMonths(-1)).Month.ToString();

        [Test]
        public void SearchWithoutEnteringTheCityOfArrival()
        {

            var departureDate = GetWebElementByClassName("ui-datepicker-trigger");
            departureDate.Click();
            var departureDateChoose = GetWebElementByXPath("//td[@data-month=" + monthOfDayAfterTomorrow + "]/descendant-or-self::a[text() = " + dayAfterTomorrowDate + "]");
            departureDateChoose.Click();
            var searchButton = GetWebElementByXPath("//input[@value='Найти']");
            searchButton.Click();
            var errorMessage = GetWebElementByXPath("//samp[@class = 'error']");
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

            const string arrivalCityText = "Москва" ;

            #endregion

            var arrivalCity = GetWebElementById("to_name");
            arrivalCity.SendKeys(arrivalCityText);
            var chooseArrivalCity = GetWebElementByXPath("//strong[text() ='Москва']");
            chooseArrivalCity.Click();
            var departureDate = GetWebElementByClassName("ui-datepicker-trigger");
            departureDate.Click();
            var departureDateChoose = GetWebElementByXPath("//td[@data-month=" + monthOfDayAfterTomorrow + "]/descendant-or-self::a[text() = " + dayAfterTomorrowDate + "]");
            departureDateChoose.Click();
            var searchButton = GetWebElementByXPath("//input[@value='Найти']");
            searchButton.Click();
           var resultOfSearchWithAllFieldsAreFull = GetWebElementByXPath("//p[text()='Время выезда/приезда: местное']");
           Assert.AreEqual(resultOfSearchWithAllFieldsAreFull.Text, message);
        }


    }
}