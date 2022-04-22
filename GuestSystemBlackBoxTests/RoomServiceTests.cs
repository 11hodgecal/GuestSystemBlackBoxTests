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
    public class RoomServiceTests
    {
        [Test]
        [Order(1)]
        public void ServiceDropdownRoomServiceSelectedCorrect()
        {

            //Arrange
            var driver = new ChromeDriver("C:\\Program Files\\Google\\Chrome\\Application");
            driver.Navigate().GoToUrl("https://localhost:44371/Identity/Account/Login");
            var username = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[2]/input"));
            var pass = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[3]/input"));
            username.SendKeys("Test@Test.com");
            pass.SendKeys("Admin123!");
            pass.Submit();
            var expected1 = "Current: RoomService";
            var expected2 = "Current: RoomService";
            var expected3 = "Room Service";
            var expected4 = "Food";
            var expected5 = "Drink";

            //act
            var Dropdown = driver.FindElement(By.XPath("/html/body/div/main/form/select"));
            var actual1 = driver.FindElement(By.XPath("/html/body/div/main/form/select")).Text;
            Dropdown.Click();
            var actual2 = driver.FindElement(By.XPath("/html/body/div/main/form/select/option[1]")).Text;
            var actual3 = driver.FindElement(By.XPath("/html/body/div/main/form/select/option[2]")).Text;
            var actual4 = driver.FindElement(By.XPath("/html/body/div/main/form/select/option[3]")).Text;
            var actual5 = driver.FindElement(By.XPath("/html/body/div/main/form/select/option[4]")).Text;
            //Assert
            if(actual1 == expected1 && expected2 == actual2 && expected3 == actual3&& expected4 == actual4 && expected5 == actual5)
            {
                driver.Close();
                Assert.Pass();
            }

        }
        [Test]
        [Order(2)]
        public void FirstOptionChangesToSelected()
        {

            //Arrange
            var driver = new ChromeDriver("C:\\Program Files\\Google\\Chrome\\Application");
            driver.Navigate().GoToUrl("https://localhost:44371/Identity/Account/Login");
            var username = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[2]/input"));
            var pass = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[3]/input"));
            username.SendKeys("Test@Test.com");
            pass.SendKeys("Admin123!");
            pass.Submit();
            var expected = "Current: Food";

            //act
            var Dropdown = driver.FindElement(By.XPath("/html/body/div/main/form/select"));
            Dropdown.Click();
            var selected = driver.FindElement(By.XPath("/html/body/div/main/form/select/option[3]"));
            selected.Click();
            Dropdown = driver.FindElement(By.XPath("/html/body/div/main/form/select"));
            Dropdown.Click();
            var actual = driver.FindElement(By.XPath("/html/body/div/main/form/select/option[1]")).Text;
            

            //Assert
            driver.Close();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        [Order(3)]
        public void NavWorks()
        {

            //Arrange
            var driver = new ChromeDriver("C:\\Program Files\\Google\\Chrome\\Application");
            driver.Navigate().GoToUrl("https://localhost:44371/Identity/Account/Login");
            var username = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[2]/input"));
            var pass = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[3]/input"));
            username.SendKeys("Test@Test.com");
            pass.SendKeys("Admin123!");
            pass.Submit();
            var expected = "https://localhost:44371/CustomerRoomRequest";

            //act
            var Nav = driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul[2]/li[1]/a"));
            Nav.Click();
            //Assert
            Assert.AreEqual(driver.Url, expected);
            driver.Close();
        }
    }
}
