using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuizPortal
{
    public class SignUpPage:CorePage
    {
        String signUpOption = "//android.widget.Button[@content-desc=\"Sign Up\"]";
        String emailLocator = "//android.widget.FrameLayout[@resource-id=\"android:id/content\"]/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View/android.view.View/android.view.View[2]/android.widget.EditText[1]";
        String passwordLocator = "//android.widget.FrameLayout[@resource-id=\"android:id/content\"]/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View/android.view.View/android.view.View[2]/android.widget.EditText[2]";
        String fullNameLocator = "//android.widget.FrameLayout[@resource-id=\"android:id/content\"]/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View/android.view.View/android.view.View[2]/android.widget.EditText[3]";
        String signUpBtn = "//android.widget.Button[@content-desc=\"Sign Up\"]";

        String successToast = "//android.widget.Toast[@text='Successfully added account']";
        String emailAlreadyInUseToast = "//android.widget.Toast[@text=\"[firebase_auth/email-already-in-use] The email address is already in use by another account.\"]";
        String networkErrorToast = "//android.widget.Toast[@text=\"[firebase_auth/network-request-failed] A network error (such as timeout, interrupted connection or unreachable host) has occurred.\"]";
        String badEmailToast = "//android.widget.Toast[@text=\"[firebase_auth/invalid-email] The email address is badly formatted.\"]";
        String badShortPassword = "//android.widget.Toast[@text=\"[firebase_auth/weak-password] Password should be at least 6 characters\"]";
        String emailMissing = "//android.view.View[@content-desc=\"Enter Email\"]";
        String passwordMissing = "//android.view.View[@content-desc=\"Enter Password\"]";
        String fullNameMissing = "//android.view.View[@content-desc=\"Enter Full Name\"]";

        public void SignUp(String username, String password, String fullname)
        {

            Step = Test.CreateNode("SignUpPage");

            Click(signUpOption);
            Click(emailLocator);
            Write(emailLocator, username);
            Click(passwordLocator);
            Write(passwordLocator, password);
            Click(fullNameLocator);
            Write(fullNameLocator, fullname);
            Click(signUpBtn);
        }

        public void CheckValidity()
        {
            // Wait and continuously check for the toast message
            bool succeed = false;
            bool failed = false;
            string toastMessage = "";
            for (int i = 0; i < 8; i++) // Check for 8 seconds
            {
                Thread.Sleep(1000); // Wait for 1 second
                if (driver.FindElements(By.XPath(successToast)).Count > 0)
                {
                    succeed = true;
                    toastMessage = "Successfully added account";
                    break;
                }
                else if (driver.FindElements(By.XPath(emailAlreadyInUseToast)).Count > 0)
                {
                    failed = true;
                    toastMessage = "The email address is already in use by another account";
                    break;
                }
                else if (driver.FindElements(By.XPath(networkErrorToast)).Count > 0)
                {
                    failed = true;
                    toastMessage = "A network error (such as timeout, interrupted connection or unreachable host) has occurred.";
                    break;
                }
                else if (driver.FindElements(By.XPath(badEmailToast)).Count > 0)
                {
                    failed = true;
                    toastMessage = "The email address is badly formatted.";
                    break;
                }
                else if (driver.FindElements(By.XPath(badShortPassword)).Count > 0)
                {
                    failed = true;
                    toastMessage = "Password should be at least 6 characters.";
                    break;
                }
                else if (driver.FindElements(By.XPath(emailMissing)).Count > 0)
                {
                    failed = true;
                    toastMessage = "email missing";
                    break;
                }
                else if (driver.FindElements(By.XPath(passwordMissing)).Count > 0)
                {
                    failed = true;
                    toastMessage = "password missing.";
                    break;
                }
                else if (driver.FindElements(By.XPath(fullNameMissing)).Count > 0)
                {
                    failed = true;
                    toastMessage = "full name missing";
                    break;
                }
            }

            if (succeed)
            {
                
                TakeScreenshot(Status.Pass, "Success toast message appeared: " + toastMessage);
            }
            else if (failed)
            {
                
                TakeScreenshot(Status.Fail, "Error toast message appeared: " + toastMessage);
            }
            else
            {
                TakeScreenshot(Status.Fail, "Some other error appeared in screenshot");
            }
        }

        public void CheckInvalidity()
        {
            

            // Wait and continuously check for the toast message
            bool errorToastAppeared = false;
            string toastMessage = "";
            bool successToastAppeared = false;
            for (int i = 0; i < 8; i++) // Check for 8 seconds
            {
                Thread.Sleep(1000); // Wait for 1 second
                if (driver.FindElements(By.XPath(successToast)).Count > 0)
                {
                    successToastAppeared = true;
                    toastMessage = "Successfully added account";
                    break;
                }
                else if (driver.FindElements(By.XPath(emailAlreadyInUseToast)).Count > 0)
                {
                    errorToastAppeared = true;
                    toastMessage = "The email address is already in use by another account";
                    break;
                }
                else if (driver.FindElements(By.XPath(networkErrorToast)).Count > 0)
                {
                    errorToastAppeared = true;
                    toastMessage = "A network error (such as timeout, interrupted connection or unreachable host) has occurred.";
                    break;
                }
                else if (driver.FindElements(By.XPath(badEmailToast)).Count > 0)
                {
                    errorToastAppeared = true;
                    toastMessage = "The email address is badly formatted.";
                    break;
                }
                else if (driver.FindElements(By.XPath(badShortPassword)).Count > 0)
                {
                    errorToastAppeared = true;
                    toastMessage = "Password should be at least 6 characters.";
                    break;
                }
                else if (driver.FindElements(By.XPath(emailMissing)).Count > 0)
                {
                    errorToastAppeared = true;
                    toastMessage = "Email Missing";
                    break;
                }
                else if (driver.FindElements(By.XPath(passwordMissing)).Count > 0)
                {
                    errorToastAppeared = true;
                    toastMessage = "password missing.";
                    break;
                }
                else if (driver.FindElements(By.XPath(fullNameMissing)).Count > 0)
                {
                    errorToastAppeared = true;
                    toastMessage = "full name missing.";
                    break;
                }
            }

            if (errorToastAppeared)
            {
                
                TakeScreenshot(Status.Pass, "Error toast message appeared: " + toastMessage);
            }
            else if (successToastAppeared)
            {
                
                TakeScreenshot(Status.Fail, "Success toast message appeared: " + toastMessage);
            }
            else
            {
                
                TakeScreenshot(Status.Fail, "Some Other Error appeared in screenshot");
            }
        }
    }
}
