using BuggyCarsRatingProject.Components.LoginAndRegister;
using BuggyCarsRatingProject.Components.ProfilePage;
using BuggyCarsRatingProject.Drivers;
using BuggyCarsRatingProject.TestData.UserData;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium.DevTools;
using TechTalk.SpecFlow;

namespace BuggyCarsRatingProject.FeatureStepDefinitions
{
    [Binding]
    public class RegisterAndAddAdditionalInfoStepDefinitions: Hook
    {
        private Register register;
        private LoginAndLogout loginAndLogout;
        private AdditionalInfo additionalInfo;

        public RegisterAndAddAdditionalInfoStepDefinitions()
        {
            register = new Register();
            loginAndLogout = new LoginAndLogout();
            additionalInfo = new AdditionalInfo();
        }

        [Given(@"I used this json file with valid credentials to resgister a new account")]
        public void GivenIUsedThisJsonFileWithValidCredentialsToResgisterANewAccount()
        {
            var jsonPath = File.ReadAllText(@"..\..\..\TestData\UserData\LoginAndRegisterData.json");
            var userData = JsonConvert.DeserializeObject<UserData>(jsonPath);

            ScenarioContext.Current.Set(userData, "UserData");
        }

        [When(@"I start enter valid username, first name, last name, password and confirm password")]
        public void WhenIStartEnterValidUsernameFirstNameLastNamePasswordAndConfirmPassword()
        {
            var jsonData = ScenarioContext.Current.Get<UserData>("UserData");

            string registerUsername = jsonData.username;
            string registerFirstname = jsonData.firstname;
            string registerLastname = jsonData.lastname;
            string registerPassword = jsonData.password;
            string registerConfirmPassword = jsonData.confirmPassword;

            register.registerAction(registerUsername, registerFirstname, registerLastname, registerPassword, registerConfirmPassword);
        }

        [Then(@"The new account should be register sucessfully by click the register button")]
        public void ThenTheNewAccountShouldBeRegisterSucessfullyByClickTheRegisterButton()
        {
            register.ClickRegisterButton();
        }

        [Then(@"I should see the register successful message")]
        public void ThenIShouldSeeTheRegisterSuccessfulMessage()
        {
            string expecedSuccessMessage = register.assertMessage();
            Assert.That(expecedSuccessMessage == "Registration is successful", "Actual message and expected message do not match!");
        }

        [Then(@"I use valid user name and valid password to login to the portal")]
        public void ThenIUseValidUserNameAndValidPasswordToLoginToThePortal()
        {
            var jsonData = ScenarioContext.Current.Get<UserData>("UserData");

            string loginUsername = jsonData.username;
            string loginPassword = jsonData.password;

            loginAndLogout.loginAction(loginUsername, loginPassword);
        }

        [Then(@"I should be able to go to my profile page to add additional info")]
        public void ThenIShouldBeAbleToGoToMyProfilePageToAddAdditionalInfo()
        {
            additionalInfo.goToProfilePage();
        }
        [Then(@"I enter valid '([^']*)','([^']*)', '([^']*)', '([^']*)' to my additional info, and select gender and hobby")]
        public void ThenIEnterValidToMyAdditionalInfoAndSelectGenderAndHobby(string userGender, string userAge, string userAddress, string userPhone)
        {
            additionalInfo.AdditionalInfoAction(userGender, userAge, userAddress, userPhone);
        }

        [Then(@"I want to change password and enter '([^']*)', '([^']*)', '([^']*)'")]
        public void ThenIWantToChangePasswordAndEnter(string currentPassword, string newPassword, string newConfirmPassword)
        {
            additionalInfo.ChangePasswordAction(currentPassword, newPassword, newConfirmPassword);
        }

        [Then(@"I click the Save button to save the changes")]
        public void ThenIClickTheSaveButtonToSaveTheChanges()
        {
            additionalInfo.ClickSaveButton();
        }

        [Then(@"I should be able to see the info save successfully message")]
        public void ThenIShouldBeAbleToSeeTheInfoSaveSuccessfullyMessage()
        {
            string expecedSuccessMessage = additionalInfo.assertMessage();
            Assert.That(expecedSuccessMessage == "The profile has been saved successful", "Actual message and expected message do not match!");
        }


        [Then(@"I click logout to logout the account")]
        public void ThenIClickLogoutToLogoutTheAccount()
        {
            loginAndLogout.logoutAction();
        }

        [Then(@"I use valid username and new password to login to the portal")]
        public void ThenIUseValidUsernameAndNewPasswordToLoginToThePortal()
        {
            var jsonData = ScenarioContext.Current.Get<UserData>("UserData");

            string loginUsername = jsonData.username;
            string loginNewPassword = jsonData.newPassword;

            loginAndLogout.loginAction(loginUsername, loginNewPassword);
        }
    }
}
