using System;
using System.Threading;
using NUnit.Framework;
using SeleniumWebDriver;

namespace Tests
{
    public class Tests:TestBase
    {
        private const string ErrorTextForEmptyString =
            "��� ���� ���������� ���������";
        private const string message = "����� ������/�������: �������";

        //        ���� 1: ����� ������ �� ������ �� ����������� ��� �������� ����� ��������

        //���� : 
        //1. ����� �� ���� https://tickets.by/gd
        //2. ��������� � ����� ������ ���� "������" - ������� ����� ����������� ������(�����)
        //3. ��������� � ����� ������ ���� "����" - ������� ���� �����������(�����������)
        //4. ������ ������ "�����" � ����� ������

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
            var searchButton = GetWebElementByXPath("//input[@value='�����']");
            searchButton.Click();
            var errorMessage = GetWebElementByXPath("//samp[@class = 'error']");
            string error = errorMessage.Text;
            Assert.AreEqual(ErrorTextForEmptyString, error);
        }




        //��������� ���������:
        // ���� "����" ���������� �������, ��� ������ ����� ������� ��������� �� ������: "��� ���� ���������� ���������".

        //        ���� 2: ������� � ������ ������ �� ������ � ������ �� �����������, �������� ��� ���� � ����� ������

        //   ����:
        //1. ����� �� ���� https://tickets.by/gd
        //2. ��������� � ����� ������ ���� "������"- ������� ����� ����������� ������(�����)
        //3. ��������� � ����� ������ ���� "����" - ������� ����� �������� ������(������)
        //4. ��������� � ����� ������ ���� "����" - ������� ���� �����������(�����������)
        //5. ������ ������ "�����" � ����� ������

        //��������� ���������:
        // ����������� �������� "����� ������"(���� ����� �������� �����), 
        // ���� ����� ������� ������� ����� ->  ������(��.��.����), 
        // ��� ���� - ������� �� ������� �������, ���� ������ �� �� ����������.


        [Test]
        public void SearchWithAllFieldsAreFull()
        {
            #region TestData

            const string arrivalCityText = "������" ;

            #endregion

            var arrivalCity = GetWebElementById("to_name");
            arrivalCity.SendKeys(arrivalCityText);
            var chooseArrivalCity = GetWebElementByXPath("//strong[text() ='������']");
            chooseArrivalCity.Click();
            var departureDate = GetWebElementByClassName("ui-datepicker-trigger");
            departureDate.Click();
            var departureDateChoose = GetWebElementByXPath("//td[@data-month=" + monthOfDayAfterTomorrow + "]/descendant-or-self::a[text() = " + dayAfterTomorrowDate + "]");
            departureDateChoose.Click();
            var searchButton = GetWebElementByXPath("//input[@value='�����']");
            searchButton.Click();
           var resultOfSearchWithAllFieldsAreFull = GetWebElementByXPath("//p[text()='����� ������/�������: �������']");
           Assert.AreEqual(resultOfSearchWithAllFieldsAreFull.Text, message);
        }


    }
}