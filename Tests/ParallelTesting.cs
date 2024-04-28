using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using SeleniumTests.BaseClass;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumTests.Utilities;

namespace SeleniumTests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Children) ]
    public class ParallelTesting
    {
        public IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new BrowserUtility().Init(driver);
        }

        [Test, Category("UAT Testing"), Category("Module1")]
        public void Parallel1()
        {
            IWebElement emailTextField = driver.FindElement(By.XPath(".//*[@id='email']"));
            emailTextField.SendKeys("Selenium C#");
        }

        [Test, Category("UAT Testing"), Category("Module1")]
        public void Parallel2()
        {
            IWebElement emailTextField = driver.FindElement(By.XPath(".//*[@id='email']"));
            emailTextField.SendKeys("Selenium C#");
        }

        [Test, Category("UAT Testing"), Category("Module1")]
        public void Parallel3()
        {
            IWebElement emailTextField = driver.FindElement(By.XPath(".//*[@id='email']"));
            emailTextField.SendKeys("Selenium C#");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}