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
    public class RequestItemTests
    {
        [Test]
        [Order(1)]
        public void RequestButtonWorks()
        {

            //Arrange
            var driver = new ChromeDriver("C:\\Program Files\\Google\\Chrome\\Application");
            driver.Navigate().GoToUrl("https://localhost:44371/Identity/Account/Login");

            var username = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[2]/input"));
            var pass = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[3]/input"));
            username.SendKeys("Test@test.com");
            pass.SendKeys("Admin123!");
            pass.Submit();

            string ExpectedURL = "https://localhost:44371/CustomerRoomRequest/Request?ItemID=2";

            //Act
            driver.FindElement(By.XPath("/html/body/div/main/div/div[1]/div/div/a")).Click();
            //Assert 
            Assert.AreEqual(ExpectedURL, driver.Url);


        }
        [Test]
        [Order(2)]
        public void RequestBackBtnWorks()
        {

            //Arrange
            var driver = new ChromeDriver("C:\\Program Files\\Google\\Chrome\\Application");
            driver.Navigate().GoToUrl("https://localhost:44371/Identity/Account/Login");

            var username = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[2]/input"));
            var pass = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[3]/input"));
            username.SendKeys("Test@test.com");
            pass.SendKeys("Admin123!");
            pass.Submit();

            string ExpectedURL = "https://localhost:44371/CustomerRoomRequest";
            driver.FindElement(By.XPath("/html/body/div/main/div/div[1]/div/div/a")).Click();
            //Act
            driver.FindElement(By.XPath("/html/body/div/main/div/form/div/a")).Click();
            //Assert 
            Assert.AreEqual(ExpectedURL, driver.Url);


        }
        [Test]
        [Order(2)]
        public void RequestContinueBtnWorks()
        {

            //Arrange
            var driver = new ChromeDriver("C:\\Program Files\\Google\\Chrome\\Application");
            driver.Navigate().GoToUrl("https://localhost:44371/Identity/Account/Login");

            var username = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[2]/input"));
            var pass = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[3]/input"));
            username.SendKeys("Test@test.com");
            pass.SendKeys("Admin123!");
            pass.Submit();

            string ExpectedURL = "https://localhost:44371/CustomerRoomRequest";
            driver.FindElement(By.XPath("/html/body/div/main/div/div[1]/div/div/a")).Click();
            //Act
            driver.FindElement(By.XPath("/html/body/div/main/div/form/div/button")).Click();
            //Assert 
            Assert.AreEqual(ExpectedURL, driver.Url);


        }
    }
}
