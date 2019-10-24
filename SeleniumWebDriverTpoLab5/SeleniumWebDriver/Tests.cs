using System;
using System.Threading;
using NUnit.Framework;
using SeleniumWebDriver;

namespace Tests
{
    public class Tests:TestBase
    {
        private const string ErrorTextForEmptyString =
            "��� ���� ���������� ���������.";

       
        //        ���� 1: ����� ������ �� ������ �� ����������� ��� �������� ����� ��������

        //���� : 
        //1. ����� �� ���� https://tickets.by/gd
        //2. ��������� � ����� ������ ���� "������" - ������� ����� ����������� ������(�����)
        //3. ��������� � ����� ������ ���� "����" - ������� ���� �����������(�����������)
        //4. ������ ������ "�����" � ����� ������

        [Test]
        public void SearchWithoutEnteringTheCityOfArrival()
        {
            #region TestData

            const string departureCityText = "�����";


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

            const string departureCityText = "�����";
            const string arrivalCityText = "������" ;

           
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