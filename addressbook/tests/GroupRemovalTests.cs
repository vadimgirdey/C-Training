using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupsList();

            app.Navigator.GoToGroupsPage();
            app.Groups.Remove(0);

            List<GroupData> newGroups = app.Groups.GetGroupsList();
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups.Count -1, newGroups.Count);



            //applicationManager.LogOut();
        }
    }
}
