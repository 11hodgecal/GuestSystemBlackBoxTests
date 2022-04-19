using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace GuestSystemBlackBoxTests
{
    public class LoginTests
    {
        [SetUp]
        public void Setup()
        {


        }
        [Test]
        [Order(1)]
        public void LoginNavWorksCorrectly()
        {
            //Arrange
            var driver = new ChromeDriver("C:\\Program Files\\Google\\Chrome\\Application");
            driver.Navigate().GoToUrl("https://localhost:44371/");
            var expectedURL = "https://localhost:44371/Identity/Account/Login";
            var expectedWord = "Login";


            //Act

            var loginnav = driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul[2]/li[2]/a"));
            loginnav.Click();
            loginnav = driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul[2]/li[2]/a"));

            //Assert

            if (loginnav.Text == expectedWord && driver.Url == expectedURL)
            {
                driver.Close();
                Assert.Pass("Success");
            }
            if (loginnav.Text != expectedWord && driver.Url != expectedURL)
            {
                driver.Close();
                Assert.Fail("did not match");
            }

        }

        [Test]
        [Order(2)]
        public void AdminSeededandLoginAndWorks()
        {
            //Arrange
            var driver = new ChromeDriver("C:\\Program Files\\Google\\Chrome\\Application");
            driver.Navigate().GoToUrl("https://localhost:44371/Identity/Account/Login");

            var expected = "Hello admin@admin.com!";

            //Act
            var username = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[2]/input"));
            var pass = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[3]/input"));
            username.SendKeys("Admin@admin.com");
            pass.SendKeys("Admin123!");

            pass.Submit();
            var Actual = driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul[2]/li[3]/a")).Text;
            driver.Close();
            //Assert

            Assert.AreEqual(expected, Actual);

        }
        [Test]
        [Order(3)]
        public void ValidationEmailErrorsAppear()
        {
            //Arrange
            var driver = new ChromeDriver("C:\\Program Files\\Google\\Chrome\\Application");
            driver.Navigate().GoToUrl("https://localhost:44371/Identity/Account/Login");

            var expected = "The Email field is required.";

            //Act
            var pass = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[3]/input"));
            pass.Submit();
            var error1 = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[1]/ul/li[1]")).Text;
            var error2 = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[2]/span/span")).Text;
            //Assert

            if (error1 == expected && error2 == expected)
            {
                driver.Close();
                Assert.Pass();
            }
            if (error1 != expected && error2 != expected)
            {
                driver.Close();
                Assert.Fail("Error not correct");
            }
        }
        [Test]
        [Order(4)]
        public void ValidationInvalidEmailFormatErrorsAppear()
        {
            //Arrange
            var driver = new ChromeDriver("C:\\Program Files\\Google\\Chrome\\Application");
            driver.Navigate().GoToUrl("https://localhost:44371/Identity/Account/Login");

            var expected = "The Email field is not a valid e-mail address.";

            //Act
            var username = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[2]/input"));
            var pass = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[3]/input"));
            username.SendKeys("test");
            pass.Submit();
            var error1 = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[1]/ul/li[1]")).Text;
            var error2 = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[2]/span/span")).Text;
            //Assert
            if (error1 == expected && error2 == expected)
            {
                driver.Close();
                Assert.Pass();
            }
            if (error1 != expected && error2 != expected)
            {
                driver.Close();
                Assert.Fail("Error not correct");
            }

        }
        [Test]
        [Order(5)]
        public void ValidationPassErrorsAppear()
        {
            //Arrange
            var driver = new ChromeDriver("C:\\Program Files\\Google\\Chrome\\Application");
            driver.Navigate().GoToUrl("https://localhost:44371/Identity/Account/Login");

            var expected = "The Password field is required.";

            //Act
            var pass = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[3]/input"));
            pass.Submit();
            var error1 = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[1]/ul/li[2]")).Text;
            var error2 = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[3]/span/span")).Text;
            //Assert

            if (error1 == expected && error2 == expected)
            {
                driver.Close();
                Assert.Pass();
            }
            if (error1 != expected && error2 != expected)
            {
                driver.Close();
                Assert.Fail("Error not correct");
            }
        }
    }
}