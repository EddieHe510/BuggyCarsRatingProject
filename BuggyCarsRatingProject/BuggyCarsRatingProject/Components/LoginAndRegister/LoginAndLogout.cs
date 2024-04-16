using BuggyCarsRatingProject.Drivers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuggyCarsRatingProject.Components.LoginAndRegister
{
    public class LoginAndLogout: Hook
    {
        private IWebElement loginUsernameTextbox => driver.FindElement(By.Name("login"));
        private IWebElement loginPasswordTextbox => driver.FindElement(By.Name("password"));
        private IWebElement loginButton => driver.FindElement(By.XPath("//*[contains(text(), 'Login')]"));
        private IWebElement logoutButton => driver.FindElement(By.XPath("//*[contains(text(), 'Logout')]"));

        public void loginAction(string loginUsername, string loginPassword)
        {
            loginUsernameTextbox.SendKeys(loginUsername);
            loginPasswordTextbox.SendKeys(loginPassword);
            loginButton.Click();
        }

        public void logoutAction()
        {
            logoutButton.Click();
        }
    }
}