using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.ComponentModel;
using System.Data;
using System.Reflection;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [TestCategory("Manipulation")]
        public void TestMethod1()
        {
            var driver = GetChromeDrive();


            driver.Navigate().GoToUrl("https://ultimateqa.com/filling-out-forms/");
            var nameField = driver.FindElement(By.Id("et_pb_contact_name_1"));
            nameField.Clear();
            nameField.SendKeys("Test");

            var textBox = driver.FindElement(By.Id("et_pb_contact_message_1"));
            textBox.Clear();
            textBox.SendKeys("Testing");

            var captchaLabel = driver.FindElement(By.ClassName("et_pb_contact_captcha_question"));
            //String[] Operands = captchaLabel.Text.Split('+');
            //if (Operands.Length == 2)
            //{
            //   if (int.TryParse(Operands[0].Trim(), out int operand1) && int.TryParse(Operands[1].Trim(), out int operand2))
            //    {
            //        var sum = operand1 + operand2;
            //        var captchaBX = driver.FindElement(By.XPath("//*[@id=\"et_pb_contact_form_1\"]/div[2]/form/div/div/p/input"));
            //        captchaBX.Clear();
            //        captchaBX.Click();
            //        captchaBX.SendKeys((sum).ToString());
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Invalid operands. Unable to convert to integers.");
            //}
            var table = new DataTable();
            var captchaLabelAnswer = (int)table.Compute(captchaLabel.Text, "");

            var captchaBX = driver.FindElement(By.XPath("//*[@id=\"et_pb_contact_form_1\"]/div[2]/form/div/div/p/input"));
            captchaBX.SendKeys(captchaLabelAnswer.ToString());
            

            var submitBtn = driver.FindElements(By.ClassName("et_pb_contact_submit"));
            submitBtn[1].Submit();

            //var successMessage = driver.FindElements(By.ClassName("et-pb-contact-message"))[1].FindElement(By.XPath("//*[@id=\"et_pb_contact_form_1\"]/div/p"));
            //Assert.IsTrue( successMessage.Text.Equals("Thanks for contacting us"));

            driver.Quit();
        }

        private IWebDriver GetChromeDrive()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }
    }
}