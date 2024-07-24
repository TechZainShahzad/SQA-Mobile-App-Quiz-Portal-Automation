using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuizPortal
{
    internal class LoginPage : CorePage
    {
        String usernameLocator = "//android.widget.FrameLayout[@resource-id='android:id/content']/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View/android.view.View/android.widget.EditText[1]";
        String passwordLocator = "//android.widget.FrameLayout[@resource-id='android:id/content']/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View/android.view.View/android.widget.EditText[2]";
        String LoginBtn = "//android.widget.Button[@content-desc='Login']";

        String succeedHomeXpath = "//android.view.View[@content-desc=\"Home Page\"]";
        //By use = By.XPath("//android.view.View[@content-desc=\"Home Page\"]");
        String networkErrorToast = "//android.widget.Toast[@text=\"[firebase_auth/network-request-failed] A network error (such as timeout, interrupted connection or unreachable host) has occurred.\"]";
        String badPassword = "//android.widget.Toast[@text=\"[firebase_auth/wrong-password] The password is invalid or the user does not have a password.\"]";
        String badEmailToast = "//android.widget.Toast[@text=\"[firebase_auth/invalid-email] The email address is badly formatted.\"]";
        String passwordMissing = "//android.view.View[@content-desc=\"Enter Password\"]";
        String emailMissing = "//android.view.View[@content-desc=\"Enter Email\"]";
        String noUserRecord = "//android.widget.Toast[@text=\"[firebase_auth/user-not-found] There is no user record corresponding to this identifier. The user may have been deleted.\"]";

        //By u = By.XPath("//android.view.View[@content-desc=\"Home Page\"]");
        public void Login(String username, String password)
        {

            Step = Test.CreateNode("LoginPage");

            Click(usernameLocator);
            Write(usernameLocator, username);
            //Write(u, username);
            Click(passwordLocator);
            Write(passwordLocator, password);
            Click(LoginBtn);
        }

        public void CheckInvalidity()
        {
            // Wait and continuously check for the toast message for 8 seconds
            bool errorToastAppeared = false;
            bool testPass = false;
            string toastMessage = "";

            for (int i = 0; i < 8; i++) // Check for 8 seconds
            {
                Thread.Sleep(1000); // Wait for 1 second
                //if(driver.FindElements(use).Count > 0)
                if (driver.FindElements(By.XPath(succeedHomeXpath)).Count > 0)
                {
                    errorToastAppeared = true;
                    toastMessage = "Unexpectedly reached the Home Page";
                    break;
                }
                else if (driver.FindElements(By.XPath(networkErrorToast)).Count > 0)
                {
                    testPass = true;
                    toastMessage = "Network error occurred during login";
                    break;
                }
                else if (driver.FindElements(By.XPath(badPassword)).Count > 0)
                {
                    testPass = true;
                    toastMessage = "Invalid password provided";
                    break;
                }
                else if (driver.FindElements(By.XPath(badEmailToast)).Count > 0)
                {
                    testPass = true;
                    toastMessage = "Invalid email format provided";
                    break;
                }
                else if (driver.FindElements(By.XPath(passwordMissing)).Count > 0 && driver.FindElements(By.XPath(emailMissing)).Count > 0)
                {
                    testPass = true;
                    toastMessage = "Both email and password are missing";
                    break;
                }
                else if (driver.FindElements(By.XPath(passwordMissing)).Count > 0)
                {
                    testPass = true;
                    toastMessage = "Password is missing";
                    break;
                }
                else if (driver.FindElements(By.XPath(emailMissing)).Count > 0)
                {
                    testPass = true;
                    toastMessage = "Email is missing";
                    break;
                }
                else if (driver.FindElements(By.XPath(noUserRecord)).Count > 0)
                {
                    testPass = true;
                    toastMessage = "No user found by this email";
                    break;
                }
            }

            if (errorToastAppeared)
            {
                TakeScreenshot(Status.Fail, "Error: " + toastMessage);
            }
            else if (testPass)
            {
                TakeScreenshot(Status.Pass, "Successfully Not Log In by This: " + toastMessage);
            }
            else
            {
                TakeScreenshot(Status.Fail, "Some Other Error appeared in screenshot");
            }
        }

        public void CheckValidity()
        {
            // Wait and continuously check for the toast message for 8 seconds
            bool errorToastAppeared = false;
            bool testPass = false;
            string toastMessage = "";

            for (int i = 0; i < 8; i++) // Check for 8 seconds
            {
                Thread.Sleep(1000); // Wait for 1 second
                if (driver.FindElements(By.XPath(succeedHomeXpath)).Count > 0)
                {
                    testPass = true;
                    toastMessage = "Expectedly reached the Home Page";
                    break;
                }
                else if (driver.FindElements(By.XPath(networkErrorToast)).Count > 0)
                {
                    errorToastAppeared = true;
                    toastMessage = "Network error occurred during login";
                    break;
                }
                else if (driver.FindElements(By.XPath(badPassword)).Count > 0)
                {
                    errorToastAppeared = true;
                    toastMessage = "Invalid password provided";
                    break;
                }
                else if (driver.FindElements(By.XPath(badEmailToast)).Count > 0)
                {
                    errorToastAppeared = true;
                    toastMessage = "Invalid email format provided";
                    break;
                }
                else if (driver.FindElements(By.XPath(passwordMissing)).Count > 0 && driver.FindElements(By.XPath(emailMissing)).Count > 0)
                {
                    errorToastAppeared = true;
                    toastMessage = "Both email and password are missing";
                    break;
                }
                else if (driver.FindElements(By.XPath(passwordMissing)).Count > 0)
                {
                    errorToastAppeared = true;
                    toastMessage = "Password is missing";
                    break;
                }
                else if (driver.FindElements(By.XPath(emailMissing)).Count > 0)
                {
                    errorToastAppeared = true;
                    toastMessage = "Email is missing";
                    break;
                }
                else if (driver.FindElements(By.XPath(noUserRecord)).Count > 0)
                {
                    errorToastAppeared = true;
                    toastMessage = "No user record found by this email";
                    break;
                }
            }

            if (errorToastAppeared)
            {
                TakeScreenshot(Status.Fail, "Error: " + toastMessage);
            }
            else if (testPass)
            {
                TakeScreenshot(Status.Pass, "Successfully Log In by This: " + toastMessage);
            }
            else
            {
                TakeScreenshot(Status.Fail, "Some Other Error appeared in screenshot");
            }
        }
    }
}
