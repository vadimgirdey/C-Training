using System;
using OpenQA.Selenium;

namespace WebAddressBookTests
{
    public class GroupHelper : HelperBase
    {

        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }


        public GroupHelper Create(GroupData group) {

            manager.navigationHelper.GoToGroupsPage();
            InitNewGroupCreation();
            FillGroupCreation(group);
            SubmitGroupCreation();

            return this;
        }

        public GroupHelper Modify(int index, GroupData newData)
        {
            manager.navigationHelper.GoToGroupsPage();
            SelectGroup(index);
            InitNewGroupModification();
            FillGroupCreation(newData);
            SubmitGroupModification();
            manager.navigationHelper.GoToGroupsPage();
            return this;
        }

        public GroupHelper Remove(int index)
        {
            SelectGroup(index);
            RemoveGroup();
            manager.Navigator.GoToGroupsPage();

            return this;
        }

        public GroupHelper FillGroupCreation(GroupData group)
        {
            
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"),group.Header);
            Type(By.Name("group_footer"),group.Footer);

            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper InitNewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitNewGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
    }
}
