using NUnit.Framework;



namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactModificatorTests : AuthTestBase
    {
        [Test]
        public void ContactModificatorTest()
        {
            ContactData contact = new ContactData("newFirstName", "newLastName");

            app.Navigator.GoToContactPage();

            app.Contact
                              .SelectContact("4")
                              .EditContact()
                              .FillContact(contact)
                              .UpdateContact();
        }
    }
}
