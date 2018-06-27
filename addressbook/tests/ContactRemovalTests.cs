using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Navigator.GoToContactPage();
            app.Contact
                              .SelectContact("4")
                              .RemoveContact()
                              .IsAlertPresent();
        }
    }
}