using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            
            GroupData group = new GroupData("name");
            group.Header = "Header";
            group.Footer = "Footer";

            List<GroupData> oldGroups = app.Groups.GetGroupsList();

            app.Groups.Create(group);

            app.Navigator.GoToHomePage();

            List<GroupData> newGroups = app.Groups.GetGroupsList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        } 
    
 

        [Test]
        public void EmptyGroupCreationTest()
        {

            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Groups.GetGroupsList();

            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGroupsList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
  