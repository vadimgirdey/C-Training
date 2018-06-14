using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        protected IWebDriver driver; 

        [Test]

        public void ContactCreationTest()
        {
            applicationManager.Navigator.GoToHomePage();
            applicationManager.Auth.Login(new AccountData("admin", "secret"));
            applicationManager.Contact
                              .GoToAddNewPage()
                              .FillContact("firstName", "lastName");
            applicationManager.LogOut();
        }
    }
}