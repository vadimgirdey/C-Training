using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {

            applicationManager.Navigator.GoToGroupsPage();
            applicationManager.Groups.Remove(1);
                              
            //applicationManager.LogOut();
        }
    }
}
