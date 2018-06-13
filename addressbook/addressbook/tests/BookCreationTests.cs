using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressBookTests
{
    [TestFixture]
    public class BookCreationTests : TestBase
    {
        protected IWebDriver driver; 

        [Test]

        public void BookCreationTest()
        {
            applicationManager.Navigator.GoToHomePage();
            applicationManager.Auth.Login(new AccountData("admin", "secret"));
            GoToAddNewPage();

            FillNewContact fill = new FillNewContact("firstName", "lastName");
            applicationManager.LogOut();
        }

        private void GoToAddNewPage()
        {
            driver.FindElement(By.XPath("//a[text()= 'add new']")).Click();
        }
    }
}