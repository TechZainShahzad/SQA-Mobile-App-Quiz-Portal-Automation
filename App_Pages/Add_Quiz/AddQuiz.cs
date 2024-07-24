using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuizPortal.App_Pages.Add_Quiz
{
    internal class AddQuiz:CorePage
    {
        String drawer = "//android.widget.Button[@content-desc=\"Open navigation menu\"]";
        String adminOption = "//android.view.View[@content-desc=\"Admin Options\"]";
        String adminKey = "//android.widget.EditText";
        String key = "03120255506";
        String dialougButton = "//android.widget.Button[@content-desc=\"OK\"]";
        String addQuestionSection = "//android.widget.Button[@content-desc=\"Add New Questions In Existing Topic\"]";
        String question = "//android.widget.FrameLayout[@resource-id=\"android:id/content\"]/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View/android.view.View/android.view.View[2]/android.widget.EditText[1]";
        String questionW = "//android.widget.ScrollView/android.widget.EditText[1]";
       
        String opt1W = "//android.widget.ScrollView/android.widget.EditText[2]";
       
        String opt2W = "//android.widget.ScrollView/android.widget.EditText[3]";
       
        String opt3W = "//android.widget.ScrollView/android.widget.EditText[4]";
        
        String opt4W = "//android.widget.ScrollView/android.widget.EditText[5]";
       
        String optCorrectW = "//android.widget.ScrollView/android.widget.EditText[6]";
        String submit = "//android.widget.Button[@content-desc=\"Add This Question\"]";

        public void AddNewQuestionInExistingTopic(String sub, String subjectTopic, String Question,String one,String two,String three,String four,String correct)
        {
            Step = Test.CreateNode("Add Questions in "+subjectTopic+" of subject "+sub);

            String subject = "//android.view.View[@content-desc=\""+sub+"\"]"; //maths x
            String topic = "//android.view.View[@content-desc=\""+subjectTopic+"\"]";   //algebra

            Click(drawer);
            Click(adminOption);
            Click(adminKey);
            Write(adminKey, key);
            Click(dialougButton);
            Thread.Sleep(2000);
            Click(addQuestionSection);
            Thread.Sleep(2000);
            Click(subject);
            Thread.Sleep(2000);
            Click(topic);
            Thread.Sleep(2000);
            Click(question);
            Thread.Sleep(2000);
            Write(questionW, Question);
            Click(opt1W);
            Write(opt1W, one);
            Click(opt2W);
            Write(opt2W, two);
            Click(opt3W);
            Write(opt3W, three);
            Click(opt4W);
            Write(opt4W, four);
            Click(optCorrectW);
            Write(opt4W, correct); //because scrolling change the button sequence
            driver.Navigate().Back();
            Click(submit);

        }
    }
}
