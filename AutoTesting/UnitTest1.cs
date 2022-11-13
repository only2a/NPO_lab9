using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace AutoTesting
{
    public class Tests
    {
        private IWebDriver driver;

        private readonly By searchBar = By.Name("search");
        private readonly By searchButton = By.ClassName("button_search");

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://wikkeo.com/search?search=фывфыв");
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test1()
        {
            String searchText = "Телефон";

            driver.FindElement(searchBar).Clear();
            driver.FindElement(searchBar).SendKeys(searchText);
            driver.FindElement(searchButton).Click();

            Assert.That(driver.Title, Is.EqualTo(searchText + " | Wikeo"));
        }
    }
}