using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace GuestSystemBlackBoxTests
{
    public class StaffManagementTests
    {
        [SetUp]
        [Order(0)]
        public void Setup()
        {
            
            
        }
        [Test]
        [Order(1)]
        public void StaffManagementNavWorksCorrectly()
        {
            
            //Arrange
            var driver = new ChromeDriver("C:\\Program Files\\Google\\Chrome\\Application");
            driver.Navigate().GoToUrl("https://localhost:44371/Identity/Account/Login");

            var username = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[2]/input"));
            var pass = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[3]/input"));
            username.SendKeys("Admin@admin.com");
            pass.SendKeys("Admin123!");
            pass.Submit();

            var ExpectedWord = "Manage Staff";
            var ExpectedURL = "https://localhost:44371/User";
            //Act

            var StaffManagementnav = driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul[2]/li[1]/a"));
            StaffManagementnav.Click();
            StaffManagementnav = driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul[2]/li[1]/a"));

            //Assert

            if (StaffManagementnav.Text == ExpectedWord && driver.Url == ExpectedURL)
            {
                driver.Close();
                Assert.Pass("Success");
            }
            if (StaffManagementnav.Text != ExpectedWord && driver.Url != ExpectedURL)
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
            
            driver.Navigate().GoToUrl("https://localhost:44371/User");
            driver.FindElement(By.XPath("/html/body/div/main/p/a")).Click();
            var expected = "Test@Test.com";

            //Act

            var Email = driver.FindElement(By.XPath("/html/body/div/main/div[1]/div/form/div[1]/input"));
            var Firstname = driver.FindElement(By.XPath("/html/body/div/main/div[1]/div/form/div[2]/input"));
            var Lastname = driver.FindElement(By.XPath("/html/body/div/main/div[1]/div/form/div[3]/input"));
            Email.SendKeys("Test@Test.com");
            Firstname.SendKeys("Test");
            Lastname.SendKeys("Test");
            Lastname.Submit();
            var Actual = driver.FindElement(By.Id("Test")).FindElement(By.XPath("//td[contains(text(),'Test@Test.com')]")).Text;
            
            //Assert
            driver.Close();
            Assert.AreEqual(expected, Actual);


        }
        [Test]
        [Order(3)]
        public void StaffManagementCreateBackWorksCorrectly()
        {

            //Arrange
            var driver = new ChromeDriver("C:\\Program Files\\Google\\Chrome\\Application");
            driver.Navigate().GoToUrl("https://localhost:44371/Identity/Account/Login");
            var expected = "https://localhost:44371/User";

            var username = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[2]/input"));
            var pass = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[3]/input"));
            username.SendKeys("Admin@admin.com");
            pass.SendKeys("Admin123!");
            pass.Submit();

            driver.Navigate().GoToUrl("https://localhost:44371/User");
            driver.FindElement(By.XPath("/html/body/div/main/p/a")).Click();

            //Act
            driver.FindElement(By.XPath("/html/body/div/main/div[2]/a")).Click();
            //Assert
            Assert.AreEqual(expected, driver.Url);
            driver.Close();
            


        }

        [Test]
        [Order(4)]
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

            driver.Navigate().GoToUrl("https://localhost:44371/User");
            var expected = "https://localhost:44371/User";

            //Act
            var DeleteButton = driver.FindElement(By.Id("Test")).FindElement(By.XPath("//td//a[contains(text(),'Delete')]"));
            DeleteButton.Click();

            var BackButton = driver.FindElement(By.XPath("/html/body/div/main/div/form/a"));
            BackButton.Click();
            //Assert
            Assert.AreEqual(expected, driver.Url);
            driver.Close();


        }
        [Test]
        [Order(5)]
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

            driver.Navigate().GoToUrl("https://localhost:44371/User");

            //Act
            var DeleteButton = driver.FindElement(By.Id("Test")).FindElement(By.XPath("//td//a[contains(text(),'Delete')]"));
            DeleteButton.Click();

            var Delete2Button = driver.FindElement(By.XPath("/html/body/div/main/div/form/input[2]"));
            Delete2Button.Click();

            //Assert
            try
            {

                driver.FindElement(By.Id("Test")).FindElement(By.XPath("//td[contains(text(),'Test@Test.com')]"));
                

            }
            catch (Exception)
            {
                driver.Close();
                Assert.Pass();
            }
        }
    }
}
