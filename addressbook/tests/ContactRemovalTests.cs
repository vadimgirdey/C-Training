using NUnit.Framework;
using System.Collections.Generic;

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
            List<ContactData> oldContacts = app.Contact.GetContactsList();

            app.Navigator.GoToContactPage();
            app.Contact
                              .RemoveContact(0)
                              .IsAlertPresent();
            List<ContactData> newContacts = app.Contact.GetContactsList();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }
    }
}