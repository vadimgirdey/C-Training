using NUnit.Framework;



namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactModificatorTests : AuthTestBase
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
        public void ContactModificatorTest()
        {
            ContactData contact = new ContactData("newFirstName", "newLastName");

            app.Navigator.GoToContactPage();


            app.Contact
                              .Modify(contact);
        }
    }
}
