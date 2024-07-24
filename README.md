## Quiz Portal Mobile App Automation

This project demonstrates a comprehensive automation testing framework for the "Quiz Portal" mobile app, developed using Selenium, Microsoft Visual Studio, C#, and Appium. The framework is designed to automate various functionalities of the app, ensuring efficiency and coverage in testing.

### Features

- **Full Automation Testing**: Performed using Selenium in Microsoft Visual Studio with C#.
- **Mobile Device Communication**: Utilized Appium and Appium WebDriver, specifically the AndroidDriver, and Selenium.support.
- **Element Identification**: Employed Appium Inspector to identify element IDs and XPaths.
- **Comprehensive Framework**: Developed with three levels: Assembly Level, Class Level, and Test Level.
- **Page Object Model (POM)**: Implemented to enhance maintainability and scalability.
- **Automated Functionalities**: Includes Signup Page, Login Page, Quiz Automation, Quiz Creation, and User Grades Verification.
- **Extensive Test Coverage**: Designed and implemented hundreds of automated tests.
- **Detailed Reporting**: Integrated ExtentReports to display test pass/fail status and reasons for failures.

### Installation Guide

#### Prerequisites

1. **Visual Studio**: Install [Microsoft Visual Studio](https://visualstudio.microsoft.com/).
2. **Appium**: Install [Appium Desktop](http://appium.io/) and ensure the Appium server is running.
3. **Node.js**: Install [Node.js](https://nodejs.org/) (required for Appium).

#### Setting Up the Project

1. **Clone the Repository**

   ```bash
   git clone  https://github.com/TechZainShahzad/SQA-Mobile-App-Quiz-Portal-Automation.git
   cd quiz-portal-automation
   ```

2. **Install Selenium and Appium Dependencies**

   - Open the project in Visual Studio.
   - Use NuGet Package Manager to install the following packages:
     - `Selenium.WebDriver`
     - `Selenium.Support`
     - `Appium.WebDriver`

3. **Configure Appium**

   - Start the Appium server and ensure it is running.

4. **Update `app.config`**

   Replace the placeholder values with your mobile device information.

   ```xml
   <appSettings>
       <add key="deviceName" value="YourDeviceName" />
       <add key="platformName" value="Android" />
       <add key="platformVersion" value="YourAndroidVersion" />
       <add key="appPackage" value="com.yourapp.package" />
       <add key="appActivity" value="com.yourapp.activity" />
   </appSettings>
   ```

5. **Run Tests**

   - Build the project in Visual Studio.
   - Execute the tests using the Test Explorer.

### Reporting

The framework generates detailed reports using ExtentReports, displaying test pass/fail status and reasons for failures. These reports can be found in the `Reports` directory after test execution.

### Contributing

Contributions are welcome! Please fork the repository and create a pull request with your changes.

### License

This project is licensed under the MIT License.

### Contact

For any queries or issues, please contact [muhammadzainshahzad7@gmail.com](mailto:muhammadzainshahzad7@gmail.com).

---

Feel free to customize this README to better suit your project's specifics. Let me know if you need further assistance!
