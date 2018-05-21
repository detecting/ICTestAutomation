using System;
using System.IO.MemoryMappedFiles;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ICTestAutomation
{
    [TestClass]
    public class UnitTest1
    {


        private string url = "https://www.google.com";
        private static IWebDriver driver;
        private string inputID = "lst-ib";
        private string inputKeywords = "github";
        private string gitUrl = "https://github.com/";


        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();

        }
        [TestMethod]
        public void GotoUrl()
        {
            driver.Navigate().GoToUrl(url);
            //location
            IWebElement inputBoxElement = driver.FindElement(By.Id(inputID));
            //input
            inputBoxElement.SendKeys(inputKeywords);
            //enter
            inputBoxElement.SendKeys(Keys.Enter);

            IWebElement webElement =
                driver.FindElement(By.LinkText("The world's leading software development platform · GitHub"));
            string getUrl = webElement.GetAttribute("href");

            Assert.IsTrue(getUrl == gitUrl);

        }


        [TestCleanup]
        public void TestCleanup()
        {
            //driver.Close();
        }

    }
}
