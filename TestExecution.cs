using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static System.Net.Mime.MediaTypeNames;
using System.Configuration;
using System.Security.Policy;
using OpenQA.Selenium;
using System.Threading;
using System.Drawing.Printing;
using AventStack.ExtentReports;
using OpenQA.Selenium.Appium;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Appium.MultiTouch;
using QuizPortal.App_Pages.Quizes;
using QuizPortal.App_Pages.Add_Quiz;
using System.Transactions;
using QuizPortal.App_Pages.transcription;


namespace QuizPortal
{
    [TestClass]
    public class TestExecution : CorePage
    {
        public TestContext instance;
        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }

        [AssemblyInitialize()]
        public static void AssemblyInit(TestContext context)
        {
            String ResultFile = @"C:\Users\Zainm\source\repos\QuizPortal\QuizPortal\ExtentReports\TestExecLog_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".html";
            CreateReport(ResultFile);
        }

        [AssemblyCleanup()]
        public static void AssemblyCleanup()
        {
            extentReports.Flush();

        }
 
        [TestInitialize()]
        public void TestInit()
        {
            SaleniumInit(ConfigurationManager.AppSettings["DeviceName"].ToString(),
                ConfigurationManager.AppSettings["platformVersion"].ToString(),
                ConfigurationManager.AppSettings["platformName"].ToString(),
                ConfigurationManager.AppSettings["automationName"].ToString(),
                ConfigurationManager.AppSettings["appActivity"].ToString(),
                ConfigurationManager.AppSettings["appPackage"].ToString(),
                ConfigurationManager.AppSettings["uri"].ToString()
                );
            Test = extentReports.CreateTest(TestContext.TestName);
        }

        [TestCleanup()]
        public void TestCleanup()
        {
            CloseSalenium();
        }

        LoginPage loginPage = new LoginPage();

        [TestMethod]
        [TestCategory("Credentials")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "LoginWithInvalidUserInvalidPassword_TC001", DataAccessMethod.Sequential)]
        public void LoginWithInvalidUserInvalidPassword_TC001()
        {
            String user = TestContext.DataRow["username"].ToString();
            String password = TestContext.DataRow["password"].ToString();

            loginPage.Login(user, password);
            loginPage.CheckInvalidity();

        }


        [TestMethod]
        [TestCategory("Credentials")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "LoginWithValidUserValidPassword_TC002", DataAccessMethod.Sequential)]
        public void LoginWithValidUserValidPassword_TC002()
        {
            String user = TestContext.DataRow["username"].ToString();
            String password = TestContext.DataRow["password"].ToString();

            loginPage.Login(user, password);
            loginPage.CheckValidity();

           

        }

        SignUpPage signUpPage = new SignUpPage();

        [TestMethod]
        [TestCategory("Credentials")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "SignUpWithValidUserValidPassword_TC003", DataAccessMethod.Sequential)]
        public void SignUpWithValidUserValidPassword_TC003()
        {
            String email = TestContext.DataRow["email"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String fullname = TestContext.DataRow["fullname"].ToString();

            signUpPage.SignUp(email, password, fullname);
            signUpPage.CheckValidity();

        }
        [TestMethod]
        [TestCategory("Credentials")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "SignUpWithInvalidUserInvalidPassword_TC004", DataAccessMethod.Sequential)]
        public void SignUpWithInvalidUserInvalidPassword_TC004()
        {
            String email = TestContext.DataRow["email"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String fullname = TestContext.DataRow["fullname"].ToString();

            signUpPage.SignUp(email, password, fullname);
            signUpPage.CheckInvalidity();
        }

        CoalBinaryDiv coalBinaryDiv = new CoalBinaryDiv();

        [TestMethod]
        [TestCategory("Quiz_Attempt")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "AttemptCoal_BinaryDivision_Quiz_TC005", DataAccessMethod.Sequential)]
        public void AttemptCoal_BinaryDivision_Quiz_TC005()
        {
            LoginWithValidUserValidPassword_TC002();

            String one = TestContext.DataRow["one"].ToString();
            String two = TestContext.DataRow["two"].ToString();
            String three = TestContext.DataRow["three"].ToString();
            String four = TestContext.DataRow["four"].ToString();
            String five = TestContext.DataRow["five"].ToString();

            coalBinaryDiv.AttemptCoalBinaryDivQuiz(one, two, three, four, five);

        }

        AddQuiz addQuiz = new AddQuiz();

        [TestMethod]
        [TestCategory("As_Admin_Question_Add")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "Attempt_To_Add_New_Questions_In_Existing_Quizs_TC006", DataAccessMethod.Sequential)]
        public void Attempt_To_Add_New_Questions_In_Existing_Quizs_TC006()
        {
            LoginWithValidUserValidPassword_TC002();

            String question = TestContext.DataRow["Question"].ToString();
            String one = TestContext.DataRow["One"].ToString();
            String two = TestContext.DataRow["Two"].ToString();
            String three = TestContext.DataRow["Three"].ToString();
            String four = TestContext.DataRow["Four"].ToString();
            String correct = TestContext.DataRow["Correct"].ToString();

            addQuiz.AddNewQuestionInExistingTopic("maths x", "calculate value of variable", question, one, two, three, four, correct);
        }

        Transcript transcript = new Transcript();


        [TestMethod]
        [TestCategory("As_Student_Check_Transcript")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "Attempt_To_Check_Transcript_TC007", DataAccessMethod.Sequential)]
        public void Attempt_To_Check_Transcript_TC007()
        {
            LoginWithValidUserValidPassword_TC002();
            transcript.CheckTranscript();
        }
    }
}
