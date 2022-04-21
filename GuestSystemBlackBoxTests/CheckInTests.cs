using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestSystemBlackBoxTests
{
    public class CheckInTests
    {
        [Test]
        [Order(1)]
        public void NoBookingCodeEnteredValidationErrorAppears()
        {
            //Arrange
            var driver = new ChromeDriver("C:\\Program Files\\Google\\Chrome\\Application");
            driver.Navigate().GoToUrl("https://localhost:44371/");
            string expected = "Please enter a booking code";
            //Act
            var BookingCode = driver.FindElement(By.XPath("/html/body/div/main/div/div/form/div[1]/input"));
            BookingCode.Submit();
            string actual = driver.FindElement(By.XPath("/html/body/div/main/div/div/form/div[1]/div[1]")).Text;
            //Assert
            driver.Close();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        [Order(2)]
        public void InvalidBookingCodeLengthValidationErrorAppears()
        {
            //Arrange
            var driver = new ChromeDriver("C:\\Program Files\\Google\\Chrome\\Application");
            driver.Navigate().GoToUrl("https://localhost:44371/");
            string expected = "Please enter a 10 character long booking code";
            //Act
            var BookingCode = driver.FindElement(By.XPath("/html/body/div/main/div/div/form/div[1]/input"));
            BookingCode.SendKeys("123");
            BookingCode.Submit();
            string actual = driver.FindElement(By.XPath("/html/body/div/main/div/div/form/div[1]/div[1]")).Text;
            //Assert
            driver.Close();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        [Order(3)]
        public void InvalidBookingCodeValidationErrorAppears()
        {
            //Arrange
            var driver = new ChromeDriver("C:\\Program Files\\Google\\Chrome\\Application");
            driver.Navigate().GoToUrl("https://localhost:44371/");
            string expected = "Invalid code";
            //Act
            var BookingCode = driver.FindElement(By.XPath("/html/body/div/main/div/div/form/div[1]/input"));
            BookingCode.SendKeys("1234567890");
            BookingCode.Submit();
            string actual = driver.FindElement(By.XPath("/html/body/div/main/div/div/form/div[1]/div[1]")).Text;
            //Assert
            driver.Close();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        [Order(4)]
        public void CorrectCurrencysAreInDropdown()
        {
            //Arrange
            var driver = new ChromeDriver("C:\\Program Files\\Google\\Chrome\\Application");
            driver.Navigate().GoToUrl("https://localhost:44371/");
            //Act
            driver.FindElement(By.XPath("/html/body/div/main/div/div/form/div[1]/select")).Click();
            var dropdown1 = driver.FindElement(By.XPath("/html/body/div/main/div/div/form/div[1]/select/option[1]")).Text;
            var dropdown2 = driver.FindElement(By.XPath("/html/body/div/main/div/div/form/div[1]/select/option[2]")).Text;
            var dropdown3 = driver.FindElement(By.XPath("/html/body/div/main/div/div/form/div[1]/select/option[3]")).Text;
            var dropdown4 = driver.FindElement(By.XPath("/html/body/div/main/div/div/form/div[1]/select/option[4]")).Text;
            //Assert
            if(dropdown1 == "Great British Pound" && dropdown2 == "US Dollar" && dropdown3 == "Euros" && dropdown4 == "Yen")
            {
                driver.Close();
                Assert.Pass();
            }
            if (dropdown1 != "Great British Pound" && dropdown2 != "US Dollar" && dropdown3 != "Euros" && dropdown4 != "Yen")
            {
                driver.Close();
                Assert.Fail("did not match");
            }
        }
        [Test]
        [Order(5)]
        public void CheckInNavWorksCorrectly()
        {
            //Arrange
            var driver = new ChromeDriver("C:\\Program Files\\Google\\Chrome\\Application");
            driver.Navigate().GoToUrl("https://localhost:44371/Identity/Account/Login");
            var expectedURL = "https://localhost:44371/";
            var expectedWord = "Check In";


            //Act

            var CheckInNav = driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul[2]/li[1]/a"));
            CheckInNav.Click();
            CheckInNav = driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul[2]/li[1]/a"));

            //Assert

            if (CheckInNav.Text == expectedWord && driver.Url == expectedURL)
            {
                driver.Close();
                Assert.Pass("Success");
            }
            if (CheckInNav.Text != expectedWord && driver.Url != expectedURL)
            {
                driver.Close();
                Assert.Fail("did not match");
            }

        }
    }
}
