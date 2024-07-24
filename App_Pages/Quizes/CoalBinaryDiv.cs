using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuizPortal.App_Pages.Quizes
{
    internal class CoalBinaryDiv: CorePage
    {
        String coalLoc = "//android.view.View[@content-desc=\"Coal\"]";
        String binaryDivLoc = "//android.view.View[@content-desc='Binary division']";
        String submit = "//android.widget.FrameLayout[@resource-id=\"android:id/content\"]/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View/android.view.View/android.widget.Button[2]";
        String next = "//android.widget.FrameLayout[@resource-id=\"android:id/content\"]/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View/android.view.View/android.widget.Button[3]";


        String backToHome = "//android.widget.Button[@content-desc=\"Back to Home\"]";

        public void AttemptCoalBinaryDivQuiz(String one, String two, String three, String four, String five)
        {

            Step = Test.CreateNode("Attempt Coal Binary Div Quiz");

            String firstQ = "//android.widget.RadioButton[@content-desc=\""+one+"\"]";
            String secondQ = "//android.widget.RadioButton[@content-desc=\""+two+"\"]";
            String thirdQ = "//android.widget.RadioButton[@content-desc=\""+three+"\"]";
            String fourthQ = "//android.widget.RadioButton[@content-desc=\""+four+"\"]";
            String fiveQ = "//android.widget.RadioButton[@content-desc=\""+five+"\"]";

            Click(coalLoc);
            Thread.Sleep(2000);

            Click(binaryDivLoc);
            Thread.Sleep(2000);

            Click(firstQ);
            Thread.Sleep(1000);

            Click(next);
            Thread.Sleep(1000);

            Click(secondQ);
            Thread.Sleep(1000);

            Click(next);
            Thread.Sleep(1000);

            Click(thirdQ);
            Thread.Sleep(1000);

            Click(next);
            Thread.Sleep(1000);

            Click(fourthQ);
            Thread.Sleep(1000);

            Click(next);
            Thread.Sleep(1000);

            Click(fiveQ);
            Thread.Sleep(1000);

            Click(submit);
            Thread.Sleep(6000);

            TakeScreenshot(Status.Pass, "Marks");

            Click(backToHome);
            Thread.Sleep(1000);

        }
    }
}
