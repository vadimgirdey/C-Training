using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        
        [Test]

        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("firstname", "lastName");

            app.Contact
                              .GoToAddNewPage()
                              .FillContact(contact);
            //applicationManager.LogOut();
        }
    }
}