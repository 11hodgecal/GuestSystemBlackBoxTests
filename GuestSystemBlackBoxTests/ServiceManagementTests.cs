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
    public class ServiceManagementTests
    {
        [Test]
        [Order(1)]
        public void LoginNavWorksCorrectly()
        {
            //Arrange
            var driver = new ChromeDriver("C:\\Program Files\\Google\\Chrome\\Application");

            driver.Navigate().GoToUrl("https://localhost:44371/Identity/Account/Login");
            var username = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[2]/input"));
            var pass = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[3]/input"));
            username.SendKeys("Admin@admin.com");
            pass.SendKeys("Admin123!");
            pass.Submit();


            var expectedURL = "https://localhost:44371/RoomServiceManagement";
            var expectedWord = "Manage Services";


            //Act

            var ServiceMNav = driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul[2]/li[2]/a"));
            ServiceMNav.Click();
            ServiceMNav = driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul[2]/li[2]/a"));

            //Assert

            if (ServiceMNav.Text == expectedWord && driver.Url == expectedURL)
            {
                driver.Close();
                Assert.Pass("Success");
            }
            if (ServiceMNav.Text != expectedWord && driver.Url != expectedURL)
            {
                driver.Close();
                Assert.Fail("did not match");
            }

        }
        [Test]
        [Order(2)]
        public void StaffManagementCreateWorksCorrectly()
        {

            //Arrange
            var driver = new ChromeDriver("C:\\Program Files\\Google\\Chrome\\Application");
            driver.Navigate().GoToUrl("https://localhost:44371/Identity/Account/Login");
            var username = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[2]/input"));
            var pass = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[3]/input"));
            username.SendKeys("Admin@admin.com");
            pass.SendKeys("Admin123!");
            pass.Submit();

            driver.Navigate().GoToUrl("https://localhost:44371/RoomServiceManagement");
            driver.FindElement(By.XPath("/html/body/div/main/p/a")).Click();
            var expected = "Test";

            //Act

            var Name = driver.FindElement(By.XPath("/html/body/div/main/div/div/form/div[1]/input"));
            var Type = driver.FindElement(By.XPath("/html/body/div/main/div/div/form/div[2]/select"));
            var Price = driver.FindElement(By.XPath("/html/body/div/main/div/div/form/div[3]/input"));
            Name.SendKeys("Test");
            Type.Click();
            driver.FindElement(By.XPath("/html/body/div/main/div/div/form/div[2]/select/option[2]")).Click();
            Price.SendKeys("10");
            Price.Submit();
            var Actual = driver.FindElement(By.Id("Test")).FindElement(By.XPath("//td[contains(text(),'Test')]")).Text;

            //Assert
            driver.Close();
            Assert.AreEqual(expected, Actual);


        }
        [Test]
        [Order(3)]
        public void StaffManagementCreateValidationWorksCorrectly()
        {

            //Arrange
            var driver = new ChromeDriver("C:\\Program Files\\Google\\Chrome\\Application");
            driver.Navigate().GoToUrl("https://localhost:44371/Identity/Account/Login");
            var username = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[2]/input"));
            var pass = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[3]/input"));
            username.SendKeys("Admin@admin.com");
            pass.SendKeys("Admin123!");
            pass.Submit();

            driver.Navigate().GoToUrl("https://localhost:44371/RoomServiceManagement");
            driver.FindElement(By.XPath("/html/body/div/main/p/a")).Click();
            var expected1 = "The Name field is required.";
            var expected2 = "The ServiceType field is required.";
            var expected3 = "The Price field is required.";

            //Act

            var Name = driver.FindElement(By.XPath("/html/body/div/main/div/div/form/div[1]/input"));
            Name.Submit();

            var Actual1 = driver.FindElement(By.XPath("/html/body/div/main/div/div/form/div[1]/span/span")).Text;
            var Actual2 = driver.FindElement(By.XPath("/html/body/div/main/div/div/form/div[2]/span/span")).Text;
            var Actual3 = driver.FindElement(By.XPath("/html/body/div/main/div/div/form/div[3]/span/span")).Text;

            //Assert
            if(Actual1 == expected1 && Actual2 == expected2 && Actual3 == expected3)
            {
                driver.Close();
                Assert.Pass("The Validation works with correct errors");
            }
            if (Actual1 != expected1 && Actual2 != expected2 && Actual3 != expected3)
            {
                driver.Close();
                Assert.Fail("The Validation does not work with incorrect errors");
            }

        }
        [Test]
        [Order(4)]
        public void StaffManagementCreateBackWorksCorrectly()
        {

            //Arrange
            var driver = new ChromeDriver("C:\\Program Files\\Google\\Chrome\\Application");
            driver.Navigate().GoToUrl("https://localhost:44371/Identity/Account/Login");
            var expected = "https://localhost:44371/RoomServiceManagement";

            var username = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[2]/input"));
            var pass = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[3]/input"));
            username.SendKeys("Admin@admin.com");
            pass.SendKeys("Admin123!");
            pass.Submit();

            driver.Navigate().GoToUrl("https://localhost:44371/RoomServiceManagement");
            driver.FindElement(By.XPath("/html/body/div/main/p/a")).Click();

            //Act
            driver.FindElement(By.XPath("/html/body/div/main/div/div/form/div[6]/a")).Click();
            //Assert
            Assert.AreEqual(expected, driver.Url);
            driver.Close();



        }
        [Test]
        [Order(5)]
        public void StaffManagementEditBackWorksCorrectly()
        {

            //Arrange
            var driver = new ChromeDriver("C:\\Program Files\\Google\\Chrome\\Application");
            driver.Navigate().GoToUrl("https://localhost:44371/Identity/Account/Login");
            var username = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[2]/input"));
            var pass = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[3]/input"));
            username.SendKeys("Admin@admin.com");
            pass.SendKeys("Admin123!");
            pass.Submit();

            driver.Navigate().GoToUrl("https://localhost:44371/RoomServiceManagement");
            var expected = "https://localhost:44371/RoomServiceManagement";

            //Act
            var EditButton = driver.FindElement(By.Id("Test")).FindElement(By.XPath("//td//a[contains(text(),'Edit Price')]"));
            EditButton.Click();

            var BackButton = driver.FindElement(By.XPath("/html/body/div/main/div[2]/a"));
            BackButton.Click();
            //Assert
            
            Assert.AreEqual(expected, driver.Url);
            driver.Close();


        }
        
        [Test]
        [Order(7)]
        public void StaffManagementDeleteBackWorksCorrectly()
        {

            //Arrange
            var driver = new ChromeDriver("C:\\Program Files\\Google\\Chrome\\Application");
            driver.Navigate().GoToUrl("https://localhost:44371/Identity/Account/Login");
            var username = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[2]/input"));
            var pass = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[3]/input"));
            username.SendKeys("Admin@admin.com");
            pass.SendKeys("Admin123!");
            pass.Submit();

            driver.Navigate().GoToUrl("https://localhost:44371/RoomServiceManagement");
            var expected = "https://localhost:44371/RoomServiceManagement";

            //Act
            var DeleteButton = driver.FindElement(By.Id("Test")).FindElement(By.XPath("//td//a[contains(text(),'Delete')]"));
            DeleteButton.Click();

            var BackButton = driver.FindElement(By.XPath("/html/body/div/main/div/div/form/a"));
            BackButton.Click();
            //Assert
            
            Assert.AreEqual(expected, driver.Url);
            driver.Close();


        }
        [Test]
        [Order(8)]
        public void StaffManagementDeleteWorksCorrectly()
        {

            //Arrange
            var driver = new ChromeDriver("C:\\Program Files\\Google\\Chrome\\Application");
            driver.Navigate().GoToUrl("https://localhost:44371/Identity/Account/Login");
            var username = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[2]/input"));
            var pass = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[3]/input"));
            username.SendKeys("Admin@admin.com");
            pass.SendKeys("Admin123!");
            pass.Submit();

            driver.Navigate().GoToUrl("https://localhost:44371/RoomServiceManagement");

            //Act
            var DeleteButton = driver.FindElement(By.Id("Test")).FindElement(By.XPath("//td//a[contains(text(),'Delete')]"));
            DeleteButton.Click();

            var Delete2Button = driver.FindElement(By.XPath("/html/body/div/main/div/div/form/input[2]"));
            Delete2Button.Click();

            //Assert
            try
            {

                driver.FindElement(By.Id("Test")).FindElement(By.XPath("//td[contains(text(),'Test')]"));


            }
            catch (Exception)
            {
                driver.Close();
                Assert.Pass();
            }
        }
    }
}
