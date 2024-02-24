using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Google.Selenium_Tests.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver;

        protected ExtentReports Extent;
        protected ExtentTest Test;
        private ExtentSparkReporter SparkReporter;

        private Dictionary<string, string> Properties;
        protected string? currdir;
        protected string url;

        //overloaded constructors

        protected BasePage()
        {
            currdir = Directory.GetParent(@"../../../")?.FullName;
        }
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
        // Common methods
        public void ReadConfigSettings()
        {
            Properties = new Dictionary<string, string>();
            
           
            string fileName = currdir + "/configsettings/config.properties";
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line) && line.Contains('='))
                {
                    string[] parts = line.Split('=');
                    string key = parts[0].Trim();
                    string value = parts[1].Trim();
                    Properties[key] = value;
                }
            }
        }
        protected static void ScrollIntoView(IWebDriver driver, IWebElement? element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
        protected string TakeScreenShot()
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)Driver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();

            string currDir = Directory.GetParent(@"../../../").FullName;
            string filepath = currDir + "/Screenshots/ss_" + DateTime.Now.ToString("yyyy/MM/dd_HHmmss") + ".png";

            screenshot.SaveAsFile(filepath);
            return filepath;
            //Console.WriteLine("Takes screenshot");

        }

        protected void LogTestResult(string testName, string type, ExtentTest Test, string result, string? errorMessage = null)
        {
            if (type.ToLower().Equals("info"))
            {
                Log.Information(result);
                Log.Information(result);
                Test?.Info(result);

            }
            else if (type.ToLower().Equals("pass") && errorMessage == null)
            {
                Log.Information(testName + " Passed");
                Log.Information("-------------------");
                Test?.Pass(result);
            }
            else
            {
                var sspath = TakeScreenShot();
                Log.Error($"Test failed for {testName}. \n Exception: \n {errorMessage}");
                Log.Information("----------------------");
                //var screenshot = ((ITakesScreenshot)Driver).GetScreenshot().AsBase64EncodedString;
                Test?.AddScreenCaptureFromPath(sspath, testName);
                Test?.Fail(result);
            }
        }
        protected void InitializeDriver()
        {
            ReadConfigSettings();
            if (Properties["browser"].ToLower() == "chrome")
            {
                Driver = new ChromeDriver();
            }
            else if (Properties["browser"].ToLower() == "edge")
            {
                Driver = new EdgeDriver();
            }
            url = Properties["baseUrl"];
            Driver.Url = url;
            Driver.Manage().Window.Maximize();
        }
        [OneTimeSetUp]
        public void Setup()
        {
            InitializeDriver();
            // Confgure Serilog
            string? logfilepath = currdir + "/Logs/log_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
            //.WriteTo.Console()
            .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
            .CreateLogger();

            // Configure Extent Report
            Extent = new ExtentReports();
            SparkReporter = new ExtentSparkReporter(currdir + "/Reports/report-"
                + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".html");

            Extent?.AttachReporter(SparkReporter);
        }
        [OneTimeTearDown]
        public void TearDown()
        {
            Driver?.Quit();
            Extent?.Flush();
            Log.CloseAndFlush();
        }
        protected static void WaitForElementToBeClickable(IWebElement? element, string elementName)
        {
            if (element != null)
            {
                DefaultWait<IWebElement> fluentWait = new DefaultWait<IWebElement>(element);
                fluentWait.Timeout = TimeSpan.FromSeconds(5);
                fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
                fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                fluentWait.Message = "Element - " + elementName + " - not found or " + "not clickable";

                fluentWait.Until(x => x != null && x.Displayed && x.Enabled);
            }
        }

    }
}
