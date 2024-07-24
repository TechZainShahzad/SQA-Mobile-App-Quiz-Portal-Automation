using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuizPortal
{
    public class CorePage
    {
        public static AndroidDriver<AndroidElement> driver;

        public static ExtentReports extentReports;
        public static ExtentTest Test;
        public static ExtentTest Step;

        public static void SaleniumInit(String deviceName, String platformVersion, String platformName,
            String automationName, String appActivity, String appPackage,String uri)
        {
            AppiumOptions options = new AppiumOptions();
            options.AddAdditionalCapability("appium:deviceName", deviceName);
            options.AddAdditionalCapability("appium:platformVersion", platformVersion);
            options.AddAdditionalCapability("platformName", platformName);
            options.AddAdditionalCapability("appium:automationName", automationName);
            options.AddAdditionalCapability("appium:appActivity", appActivity);
            options.AddAdditionalCapability("appium:appPackage", appPackage);
            driver = new AndroidDriver<AndroidElement>(new Uri(uri), options);
            Thread.Sleep(5000);
        }

        public static void CloseSalenium()
        {
            driver.Dispose();
            driver.Quit();
        }
        
        public void Write(string xpath, String data)
        {
            try
            {
                driver.FindElement(By.XPath(xpath)).SendKeys(data);
                TakeScreenshot(Status.Pass, "Data Entered Successfully");
            }
            catch (Exception ex)
            {
                TakeScreenshot(Status.Fail, "Failed to enter data: " + ex);
            }
        }
        
/*
        public void Write(By by, String data)
        {
            try
            {
                driver.FindElement(by).SendKeys(data);
                TakeScreenshot(Status.Pass, "Data Entered Successfully");
            }
            catch (Exception ex)
            {
                TakeScreenshot(Status.Fail, "Failed to enter data: " + ex);
            }
        }
*/
        public void Click(string xpath)
        {
            try
            {
                driver.FindElement(By.XPath(xpath)).Click();
                TakeScreenshot(Status.Pass, "Clicked Successfully");
            }
            catch (Exception ex)
            {
                TakeScreenshot(Status.Fail, "Clicked Failed: " + ex);
            }
        }

        public void Clear(string xpath)
        {
            driver.FindElement(By.XPath(xpath)).Clear();
        }

        public void OpenUrl(String url)
        {
            driver.Url = url;
        }

        public static void CreateReport(String path)
        {
            extentReports = new ExtentReports();

            var sparkReporter = new ExtentSparkReporter(path);
            extentReports.AttachReporter(sparkReporter);
        }

        public static void TakeScreenshot(Status status, String stepDetails)  
        {
            string path = @"C:\Users\Zainm\source\repos\QuizPortal\QuizPortal\ExtentReports\images\"
+ DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";

            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            File.WriteAllBytes(path, screenshot.AsByteArray);

            Step.Log(status, stepDetails, MediaEntityBuilder.CreateScreenCaptureFromPath(path).Build());
        }
    }
}
