@ECHO OFF
ECHO Demo Automation Execution Started.


set "summaryPath=C:\Users\Zainm\source\repos\QuizPortal\QuizPortal\TestSummaryReport"
set "trxFile=%summaryPath%\Credentials.trx"


call "C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\Tools\VsDevCmd.bat"


VSTEST.Console.exe "C:\Users\Zainm\source\repos\QuizPortal\QuizPortal\bin\Debug\QuizPortal.dll" /TestCaseFilter:"TestCategory=%testcategory%"

cd C:\Users\Zainm\source\repos\UnitTestProject1\UnitTestProject1\bin\Debug\
TrxToHTML.exe %summaryPath%


PAUSE
