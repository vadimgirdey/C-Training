using System;
using OpenQA.Selenium;
namespace WebAddressBookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper (ApplicationManager manager) : base(manager)
        {
        }


        public ContactHelper FillContact(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.firstName);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.lastName);
            return this;
        }



        public ContactHelper GoToAddNewPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
    }
}
