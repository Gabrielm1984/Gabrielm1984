using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.IO;

namespace CoinMarketCap.Tests
{
    public class CoinMarketCap
    {
        IWebDriver driver;
        [SetUp]
        public void BeforeEach()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void Coin_Display_on_Page()
        {
            //1. Go to https://www.coingecko.com/en
            driver.Url = "https://www.coingecko.com/en";

            //2. Sort by 1h
            IWebElement Change1h = driver.FindElement(By.XPath("//*/table/thead/tr/th[contains(@class,'change1h')]"));
            Change1h.Click();
            //3. Getthe all 100 coin 
            IList<IWebElement> coinesList = driver.FindElements(By.XPath("//*/table/tbody/tr/td[contains(@class,'coin-name')]"));
            IList<string> CoinListStr = new List<string>();
            foreach (var item in coinesList)
            {
                CoinListStr.Add(item.GetAttribute("data-sort").ToString());
            }
            Assert.Pass();
        }

        [TearDown]
        public void AfterEach()
        {
            driver.Quit();
        }
    }
}