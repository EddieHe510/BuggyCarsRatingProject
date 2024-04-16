using AimyOneLoginTest.Drivers;
using BuggyCarsRatingProject.Drivers;
using OpenQA.Selenium;

namespace BuggyCarsRatingProject.Components.ProfilePage
{
    public class AdditionalInfo : Hook
    {
        // Additional info: User details
        private IWebElement profileButton => driver.FindElement(By.XPath("//*[@href=\"/profile\"]"));
        private IWebElement gender => driver.FindElement(By.Id("gender"));
        //private IWebElement genderMaleOption => driver.FindElement(By.XPath("/html/body/my-app/div/main/my-profile/div/form/div[1]/div[2]/div/div/fieldset[1]/datalist/option[1]"));
        private IWebElement ageTextbox => driver.FindElement(By.Id("age"));
        private IWebElement addressTextbox => driver.FindElement(By.Id("address"));
        private IWebElement phoneTextbox => driver.FindElement(By.Id("phone"));
        private IWebElement hobbyList => driver.FindElement(By.Id("hobby"));
        private IWebElement hobbyVideoGameOption => driver.FindElement(By.XPath("//*[contains(text(), 'Video Games')]"));

        // Additional info: Change account password
        private IWebElement currentPasswordTextbox => driver.FindElement(By.Id("currentPassword"));
        private IWebElement newPasswordTextbox => driver.FindElement(By.Id("newPassword"));
        private IWebElement confirmPasswordTextbox => driver.FindElement(By.Id("newPasswordConfirmation"));
        private IWebElement languageList => driver.FindElement(By.Id("language"));
        private IWebElement languageEnglishOption => driver.FindElement(By.XPath("//*[contains(text(), 'English')]"));

        private IWebElement saveButton => driver.FindElement(By.XPath("//*[contains(text(), 'Save')]"));
        private IWebElement cancelButton => driver.FindElement(By.XPath("//*[contains(text(), 'Cancel')]"));

        // Assert profile save message
        private IWebElement infoSaveSuccessfulMessage => driver.FindElement(By.XPath("//div[2][contains(text(), 'The profile has been saved successful')]"));


        public void goToProfilePage()
        {
            FluentWait.WaitToBeClickable("XPath", 5, "//*[@href=\"/profile\"]");
            profileButton.Click();
        }

        public void AdditionalInfoAction(string userGender, string userAge, string userAddress, string userPhone)
        {
            gender.SendKeys(userGender);
            ageTextbox.SendKeys(userAge);
            addressTextbox.SendKeys(userAddress);
            phoneTextbox.SendKeys(userPhone);
            hobbyList.Click();
            hobbyVideoGameOption.Click();
        }

        public void ChangePasswordAction(string currentPassword, string newPassword, string newConfirmPassword)
        {
            currentPasswordTextbox.SendKeys(currentPassword);
            newPasswordTextbox.SendKeys(newPassword);
            confirmPasswordTextbox.SendKeys(newConfirmPassword);
            languageList.Click();
            FluentWait.WaitToBeClickable("XPath", 5, "//*[contains(text(), 'English')]");
            languageEnglishOption.Click();
        }

        public void ClickSaveButton()
        {
            saveButton.Click();
        }

        public void ClickCancelButton()
        {
            cancelButton.Click();
        }
        public string assertMessage()
        {
            FluentWait.WaitToBeVisible("XPath", 5, "//div[2][contains(text(), 'The profile has been saved successful')]");
            return infoSaveSuccessfulMessage.Text;
        }

    }
}
