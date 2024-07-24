@ECHO OFF
ECHO Demo Automation Execution Started.


set "summaryPath=C:\Users\Zainm\source\repos\QuizPortal\QuizPortal\TestSummaryReport"
set "trxFile=%summaryPath%\As_Admin_Question_Add.trx"
set "testcategory=As_Admin_Question_Add"

REM As_Admin_Question_Add
REM Quiz_Attempt
REM Credentials
REM As_Student_Check_Transcript

call "C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\Tools\VsDevCmd.bat"


VSTEST.Console.exe "C:\Users\Zainm\source\repos\QuizPortal\QuizPortal\bin\Debug\QuizPortal.dll" /TestCaseFilter:"TestCategory=%testcategory%" /Logger:"trx;LogFileName=%trxFile%"


cd C:\Users\Zainm\source\repos\UnitTestProject1\UnitTestProject1\bin\Debug\
TrxToHTML.exe %summaryPath%


PAUSE
