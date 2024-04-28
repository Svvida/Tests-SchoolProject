using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests
{
    [TestFixture]
    public class DataDrivenTesting
    {
        [Test]
        [Author("Krystian Świda","krystian.swida@microsoft.wsei.edu.pl")]
        [Description("Facebook login verify")]
        [TestCaseSource("DataDrivenTest")]
        public void TestNoPass_TakeScreenshot(String urlName)
        {
            IWebDriver driver = null;
            try
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                //driver.Url = "https://www.facebook.com/";
                driver.Url = urlName;
                //IWebElement emailTextField = driver.FindElement(By.XPath(".//*[@id='email']"));
                IWebElement emailTextField = driver.FindElement(By.XPath(".//*[@id='abcd']"));
                emailTextField.SendKeys("Selenium C#");
                driver.Quit();
            }
            catch (Exception e)
            {
                TakeScreenshot(driver, "Test1");
                Console.WriteLine(e.StackTrace);
                throw;
            }
            finally
            {
                if(driver is not null)
                {
                    driver.Quit();
                }
            }
        }

        private void TakeScreenshot(IWebDriver driver, string screenshotName)
        {
            var timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");

            var currentAssemblyDirectory = Path.GetDirectoryName(new Uri(typeof(DataDrivenTesting).Assembly.Location).LocalPath);

            var relativePath = Path.GetFullPath(Path.Combine(currentAssemblyDirectory, @"..\..\..\Screenshots"));
            var screenshotFilePath = Path.Combine(relativePath, $"{screenshotName}_{timestamp}.png");

            // Ensure the directory exists
            Directory.CreateDirectory(relativePath);

            if (driver is ITakesScreenshot takesScreenshot)
            {
                var screenshot = takesScreenshot.GetScreenshot();
                screenshot.SaveAsFile(screenshotFilePath);
                TestContext.AddTestAttachment(screenshotFilePath, "Screenshot on error"); // Attach the screenshot in NUnit result report
            }
        }

        static IList DataDrivenTest()
        {
            ArrayList list = new ArrayList();
            list.Add("https://www.facebook.com/");
            //list.Add("https://www.youtube.com/");
            //list.Add("https://www.gmail.com/");

            return list;
        }

        [Test]
        [Author("Krystian Świda", "krystian.swida@microsoft.wsei.edu.pl")]
        [Description("Facebook login verify")]
        [TestCaseSource("DataDrivenTest")]
        public void TestPass(String urlName)
        {
            IWebDriver driver = null;
            try
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                driver.Url = urlName;
                IWebElement emailTextField = driver.FindElement(By.XPath(".//*[@id='email']"));
                emailTextField.SendKeys("Selenium C#");
                driver.Quit();
            }
            catch (Exception e)
            {
                TakeScreenshot(driver, "Test1");
                Console.WriteLine(e.StackTrace);
                throw;
            }
            finally
            {
                if (driver is not null)
                {
                    driver.Quit();
                }
            }
        }
    }
}
