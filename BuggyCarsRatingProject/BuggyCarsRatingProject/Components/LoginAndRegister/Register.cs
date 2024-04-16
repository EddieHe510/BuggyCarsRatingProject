using AimyOneLoginTest.Drivers;
using BuggyCarsRatingProject.Drivers;
using OpenQA.Selenium;

namespace BuggyCarsRatingProject.Components.LoginAndRegister
{
    public class Register: Hook
    {
        private IWebElement registerButton => driver.FindElement(By.XPath("//*[contains(text(), 'Register')]"));
        private IWebElement usernameTextbox => driver.FindElement(By.Id("username"));
        private IWebElement firstNameTextbox => driver.FindElement(By.Id("firstName"));
        private IWebElement lastNameTextbox => driver.FindElement(By.Id("lastName"));
        private IWebElement passwordTextbox => driver.FindElement(By.Id("password"));
        private IWebElement confirmPasswordTextbox => driver.FindElement(By.Id("confirmPassword"));
        private IWebElement confirmRegisterButton => driver.FindElement(By.XPath("//form/button[contains(text(), 'Register')]"));
        private IWebElement registerSuccessMessage => driver.FindElement(By.XPath("//*[contains(text(), 'Registration is successful')]"));
        public void registerAction(string username, string firstname, string lastname, string password, string confirmPassword)
        {
            registerButton.Click();
            usernameTextbox.SendKeys(username);
            firstNameTextbox.SendKeys(firstname);
            lastNameTextbox.SendKeys(lastname);
            passwordTextbox.SendKeys(password);
            confirmPasswordTextbox.SendKeys(confirmPassword);
        }

        public void ClickRegisterButton()
        {
            confirmRegisterButton.Click();
        }

        public string assertMessage()
        {
            FluentWait.WaitToBeVisible("XPath", 5, "//*[contains(text(), 'Registration is successful')]");
            return registerSuccessMessage.Text;
        }
    }
}