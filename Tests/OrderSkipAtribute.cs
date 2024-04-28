using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using SeleniumTests.BaseClass;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

namespace SeleniumTests
{
    [TestFixture]
    public class OrderSkipAtribute
    {
        [Test, Order(2), Category("OrderSkipAttribute")]
        public void ChromeTest_Ignore()
        {
            Assert.Ignore("This test is ignored!");

            IWebDriver driver = new ChromeDriver();

            driver.Url = "https://www.facebook.com/";
            IWebElement emailTextField = driver.FindElement(By.XPath(".//*[@id='email']"));
            emailTextField.SendKeys("Selenium C#");

            driver.Quit();
        }
        [Test,Order(1), Category("OrderSkipAttribute")]
        public void FirefoxTest()
        {
            IWebDriver driver = new FirefoxDriver();

            driver.Url = "https://www.facebook.com/";
            IWebElement emailTextField = driver.FindElement(By.XPath(".//*[@id='email']"));
            emailTextField.SendKeys("Selenium C#");

                driver.Quit();
            
        }
        [Test, Order(0), Category("OrderSkipAttribute")]
        public void EdgeTest()
        {
            IWebDriver driver = new EdgeDriver();

            driver.Url = "https://www.facebook.com/";
            IWebElement emailTextField = driver.FindElement(By.XPath(".//*[@id='email']"));
            emailTextField.SendKeys("Selenium C#");

            driver.Quit();
        }

    }
}