using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressBookTests
{
    public class ContactHelper : HelperBase
    {
        private bool acceptNextAlert;

        public bool IsPresent()
        {
            return IsElementPresent(By.XPath("//tr[@name='entry']"));
        }

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.navigationHelper.GoToHomePage();
            InitContactCreation();
            FillContact(contact);

            return this;
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new"));
            return this;
        }

        public ContactHelper Modify(ContactData newData)
        {
            manager.navigationHelper.GoToHomePage();
            EditContact();
            FillContact(newData);
            UpdateContact();

            return this;
        }

        private ContactHelper InitNewGroupModification(int index)
        {
            driver.FindElement(By.XPath("(.//*[@alt='Edit'])[" + index + "]")).Click();
            return this;
        }

        public List<ContactData> GetList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GoToHomePage();
            ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
            foreach (IWebElement element in elements)
            {
                string firstName;
                string lastName;
                ContactData contact = new ContactData
                (
                    firstName = element.FindElement(By.XPath(".//td[3]")).Text,
                    lastName = element.FindElement(By.XPath(".//td[2]")).Text
                );

                contacts.Add(contact);
            }
            return contacts;
        }


        public ContactHelper FillContact(ContactData contact)
        {
            Type(By.Name("firstname"), contact.firstName);
            Type(By.Name("lastname"),contact.lastName);

            return this;
        }

        public ContactHelper UpdateContact()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            return this;
        }

        public ContactHelper SelectContactByID(int name)
        {
            string newString = name.ToString();
            driver.FindElement(By.Id(newString)).Click();
            return this;
        }

        public ContactHelper EditContact()
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[2]")).Click();
            return this;
        }

        public ContactHelper GoToAddNewPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
