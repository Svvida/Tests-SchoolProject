using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using System;
using System.IO;

namespace SeleniumTests.BaseClass
{
    public class BaseTest  : IDisposable
    {
        public IWebDriver driver;

        [SetUp]
        public void Open()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-extensions");
            options.AddArguments("--disable-notifications");

            driver = new ChromeDriver(options);

            driver.Manage().Window.Maximize();
            driver.Url = "https://www.facebook.com/";
        }

        [TearDown]
        public void Close()
        {
            driver.Manage().Cookies.DeleteAllCookies();
            Dispose();
        }

        public void Dispose()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }

    }
}
