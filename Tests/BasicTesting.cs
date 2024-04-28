using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using SeleniumTests.BaseClass;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumTests
{
    [TestFixture]
    public class BasicTesting : BaseTest
    {
        [Test, Category("Smoke testing")]
        public void Test1()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            var acceptButtons = driver.FindElements(By.XPath("//*[contains(text(), 'Allow all cookies')]"));
            var clickableAcceptButton = acceptButtons.FirstOrDefault(btn => btn.Displayed && btn.Enabled);
            clickableAcceptButton?.Click();

            var registerButton = driver.FindElement(By.CssSelector("[data-testid='open-registration-form-button']"));
            registerButton.Click();

            var monthDropdownList = wait.Until(drv => drv.FindElement(By.XPath(".//*[@id='month']")));

            SelectElement selectMonth = new SelectElement(monthDropdownList);
            selectMonth.SelectByIndex(1); // January
            selectMonth.SelectByText("Mar"); // March
            selectMonth.SelectByValue("5"); // May
        }

        [Test, Category("Regression testing")]
        public void Test2()
        {
            IWebElement emailTextField = driver.FindElement(By.XPath(".//*[@id='email']"));
            emailTextField.SendKeys("Selenium C#");
        }

        [Test, Category("Smoke testing")]
        public void Test3()
        {
            IWebElement emailTextField = driver.FindElement(By.XPath(".//*[@id='email']"));
            emailTextField.SendKeys("Selenium C#");
            Thread.Sleep(2000);
        }
    }
}