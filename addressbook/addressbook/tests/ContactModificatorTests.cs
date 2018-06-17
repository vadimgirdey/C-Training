using NUnit.Framework;



namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactModificatorTests : TestBase
    {
        [Test]
        public void ContactModificatorTest()
        {
            ContactData contact = new ContactData("newFirstName", "newLastName");

            applicationManager.Navigator.GoToContactPage();

            applicationManager.Contact
                              .SelectContact("4")
                              .EditContact()
                              .FillContact(contact)
                              .UpdateContact();
        }
    }
}
