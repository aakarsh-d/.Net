using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;


namespace Selenium
{
    public class LoginTest
    {
        IWebDriver driver;
        ExtentReports extent;
        ExtentTest test = null;

        [OneTimeSetUp]
        public void SetupReporting()
        {
            var htmlReporter = new ExtentSparkReporter("TestReport.html");
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }
        [SetUp]
        public void StartBrowser()
        {
            // Prefer a local driver folder if present, otherwise fall back to default ChromeDriver()
            var driverFolder = @"C:\WebDrivers";
            if (Directory.Exists(driverFolder) && File.Exists(Path.Combine(driverFolder, "chromedriver.exe")))
            {
                driver = new ChromeDriver(driverFolder);
            }
            else
            {
                try
                {
                    driver = new ChromeDriver();
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException($"ChromeDriver executable not found at '{driverFolder}' and default ChromeDriver() failed. Install chromedriver or add the Selenium.WebDriver.ChromeDriver NuGet package.", ex);
                }
            }
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
        }

        [Test]
        public void LoginToOrangeHRMS()
        {
            test = extent.CreateTest("Login Test").Info("Test Started");

            try
            {
                // Wait for and find the username field (try several common selectors)
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement username = wait.Until(d =>
                {
                    var els = d.FindElements(By.Name("username"));
                    if (els.Count > 0 && els[0].Displayed) return els[0];
                    els = d.FindElements(By.Id("txtUsername"));
                    if (els.Count > 0 && els[0].Displayed) return els[0];
                    els = d.FindElements(By.CssSelector("input[name='username']"));
                    if (els.Count > 0 && els[0].Displayed) return els[0];
                    return null;
                });

                username.SendKeys("Admin");

                // Wait for and find the password field
                IWebElement password = wait.Until(d =>
                {
                    var els = d.FindElements(By.Name("password"));
                    if (els.Count > 0 && els[0].Displayed) return els[0];
                    els = d.FindElements(By.Id("txtPassword"));
                    if (els.Count > 0 && els[0].Displayed) return els[0];
                    els = d.FindElements(By.CssSelector("input[type='password']"));
                    if (els.Count > 0 && els[0].Displayed) return els[0];
                    return null;
                });

                password.SendKeys("admin123");

                // Wait for and click submit/login button
                IWebElement submit = wait.Until(d =>
                {
                    var els = d.FindElements(By.CssSelector("button[type='submit']"));
                    if (els.Count > 0 && els[0].Displayed) return els[0];
                    els = d.FindElements(By.Id("btnLogin"));
                    if (els.Count > 0 && els[0].Displayed) return els[0];
                    els = d.FindElements(By.CssSelector("button.oxd-button"));
                    if (els.Count > 0 && els[0].Displayed) return els[0];
                    return null;
                });

                submit.Click();

                // wait for the URL to contain 'dashboard' (or for a dashboard-specific element)
                bool navigated = wait.Until(d => d.Url != null && d.Url.Contains("dashboard"));
                if (!navigated)
                {
                    test.Fail("Expected to navigate to a URL containing 'dashboard' after login.");
                    throw new Exception("Expected to navigate to a URL containing 'dashboard' after login.");
                }
                test.Pass("Login successful");
            }
            catch (Exception ex)
            {
                test.Fail("Test failed: " + ex.Message);
                throw;
            }
        }
        [TearDown]
        public void EndTest()
        {
            driver?.Quit();
            driver?.Dispose();
        }

        [OneTimeTearDown]
        public void GenerateReport()
        {
            extent.Flush();
        }
    }
}