using NUnit.Framework;
using System.Collections.Generic;

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
            ContactData newContact = new ContactData("newFirstName", "newLastName");
            List<ContactData> oldContacts = app.Contact.GetContactsList();
            ContactData oldContact = oldContacts[0];
            app.Contact.Modify(0, newContact);

            Assert.AreEqual(oldContacts.Count, app.Contact.GetContactsList().Count);

            List<ContactData> newContacts = app.Contact.GetContactsList();
            oldContacts[0].fName = newContact.fName;
            oldContacts[0].lName = newContact.lName;
            oldContacts[0].Id = newContact.Id;
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldContact.Id)
                {
                    Assert.AreEqual(newContact.fName, contact.fName);
                }
            }
        }
    }
}
