using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [SetUp]
        public void VerificationTest()
        {
            if (!app.Contact.IsPresent())
            {
                ContactData contact = new ContactData("name", "lastName");

                app.Contact.Create(contact);
                app.Navigator.GoToHomePage();
            }
        }

        [Test]
        public void ContactRemovalTest()
        {
            app.Navigator.GoToContactPage();
            app.Contact
                              .SelectContactByID(1)
                              .RemoveContact()
                              .IsAlertPresent();
        }
    }
}