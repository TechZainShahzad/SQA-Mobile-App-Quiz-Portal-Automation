using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizPortal.App_Pages.transcription
{
    internal class Transcript: CorePage
    {

        String drawer = "//android.widget.Button[@content-desc=\"Open navigation menu\"]";
        String transcriptButton = "//android.view.View[@content-desc=\"Transcript\"]";
        String coal = "//android.view.View[@content-desc=\"Coal\"]";
        String DAA = "//android.view.View[@content-desc=\"DAA\"]";
        String math = "//android.view.View[@content-desc=\"maths x\"]";

        public void CheckTranscript()
        {
            Step = Test.CreateNode("Checking all transcript records of the student");

            Click(drawer);
            Click(transcriptButton);
            Click(coal);
            TakeScreenshot(Status.Pass, "Transcript of coal");
            driver.Navigate().Back();
            Click(DAA);
            TakeScreenshot(Status.Pass, "Transcript of DAA");
            driver.Navigate().Back();
            Click(math);
            TakeScreenshot(Status.Pass, "Transcript of math");
            driver.Navigate().Back();


        }

    }
}
