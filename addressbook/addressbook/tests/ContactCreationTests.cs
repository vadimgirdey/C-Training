using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        
        [Test]

        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("firstname", "lastName");

            applicationManager.Contact
                              .GoToAddNewPage()
                              .FillContact(contact);
            //applicationManager.LogOut();
        }
    }
}