using CompleteCodes.PageObjects;
using CompleteCodes.Utilities;
using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteCodes.TestScripts
{
    internal class LoginModuleTests : CoreCodes
    {

        [Test]
        public void CreateAccountTest()
        {
            string? currdir = Directory.GetParent(@"../../../")?.FullName;
            string? logfilepath = currdir + "/Logs/log_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
           .WriteTo.Console()
           .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
           .CreateLogger();


            HomePage bchp = new(driver);
            Log.Information("Create Account Test Started");
            bchp.ClickCreateAnAccountLink();
            Log.Information("Create Account Link Clicked");
            Thread.Sleep(2000);

            try
            {
                /*       Assert.That(driver?.FindElement(By.XPath("//div[" +
                            "@class='modal-inner-wrap']//following::h1[2]")).Text,
                            Is.EqualTo("Create an Account"));*/

                Assert.IsTrue(driver?.FindElement(By.XPath(
                    "//div[@class='modal-inner-wrap']//following::h1[2]")).Text
                    == "Create an Account", $"Test failed for Create Account");

                Log.Information("Test passed for Create Account");

                test = extent.CreateTest("Create Account Link Test");
                test.Pass("Create Account Link success");

            }
            catch (AssertionException ex)
            {
                Log.Error($"Test failed for Create Account. \n Exception: {ex.Message}");

                test = extent.CreateTest("Create Account Link Test");
                test.Fail("Create Account Link failed");
            }

            string? excelFilePath = currdir + "/TestData/InputData.xlsx";
            string? sheetName = "CreateAccount";

            List<SignUp> excelDataList = ExcelUtils.ReadSignUpExcelData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {
                string? firstName = excelData?.FirstName;
                string? lastName = excelData?.LastName;
                string? email = excelData?.Email;
                string? pwd = excelData?.Password;
                string? conpwd = excelData?.ConfirmPassword;
                string? mbno = excelData?.MobileNumber;

                //  Console.WriteLine($"First Name: {firstName}, Last Name: {lastName}, Email: {email}, Password: {pwd}, Confirm Password: {conpwd}, Mobile Number: {mbno}");
                bchp.CreateAccount(firstName, lastName, email, pwd, conpwd, mbno);
                //Assert  .........
            }
            Log.CloseAndFlush();
        }

        /*   [Test]
           public void CreateAccountTest()
           {
               string? currdir = Directory.GetParent(@"../../../")?.FullName;
               string? logfilepath = currdir + "/Logs/log_" +
                   DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

               Log.Logger = new LoggerConfiguration()
               .WriteTo.Console()
               .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
               .CreateLogger();

               HomePage bchp = new(driver);

               bchp.ClickCreateAnAccountLink();
               Thread.Sleep(2000);

               try
               {
                   Assert.IsTrue(driver?.FindElement(By.XPath("//div[@class='modal-inner-wrap']//following::h1[2]")).Text == "Create an Account");
                   LogTestResult("Create Account Link Test", "Create Account Link success" );
               }
               catch (AssertionException ex)
               {
                   LogTestResult("Create Account Link Test", "Create Account Link failed", ex.Message);
               }


               string? excelFilePath = currdir + "/TestData/InputData.xlsx";
               string? sheetName = "CreateAccount";

               List<SignUp> excelDataList = ExcelUtils.ReadSignUpExcelData(excelFilePath, sheetName);

               foreach (var excelData in excelDataList)
               {
                   string? firstName = excelData?.FirstName;
                   string? lastName = excelData?.LastName;
                   string? email = excelData?.Email;
                   string? pwd = excelData?.Password;
                   string? conpwd = excelData?.ConfirmPassword;
                   string? mbno = excelData?.MobileNumber;

                   //  Console.WriteLine($"First Name: {firstName}, Last Name: {lastName}, Email: {email}, Password: {pwd}, Confirm Password: {conpwd}, Mobile Number: {mbno}");
                   bchp.CreateAccount(firstName, lastName, email, pwd, conpwd, mbno);
                   //Assert  .........
               }
               Log.CloseAndFlush();
           }
   */

    }
}