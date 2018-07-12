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
        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactsList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToContactPage();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {
                    string firstname = element.FindElement(By.XPath("./td[3]")).Text;
                    string lastName = element.FindElement(By.XPath("./td[2]")).Text;
                    string Id = element.FindElement(By.TagName("input")).GetAttribute("id");

                    contactCache.Add(new ContactData(firstname, lastName, Id));

                }
            }
            return new List<ContactData>(contactCache);
            
        }

        public int GetContactsCount()
        {
            return driver.FindElements(By.XPath("//tr[@name='entry']")).Count;
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
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper Modify(int index, ContactData newData)
        {
            manager.Navigator.GoToContactPage();
            InitNewContactModification(index);
            FillContact(newData);
            manager.Navigator.GoToContactPage();
            //UpdateContact();

            return this;
        }

        private ContactHelper InitNewContactModification(int index)
        {
            SelectContact(index);
            driver.FindElement(By.XPath($"(//tr[@name='entry'])[{ index + 1}]//img[@title='Edit']")).Click();
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
            Type(By.Name("firstname"), contact.fName);
            Type(By.Name("lastname"),contact.lName);

            if (IsElementPresent(By.Name("submit")))
            {
                driver.FindElement(By.Name("submit")).Click();
            }
            else
            {
                driver.FindElement(By.Name("update")).Click();
            }
            

            return this;
        }

        public ContactHelper UpdateContact()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            return this;
        }

        public ContactHelper RemoveContact(int index)
        {
            SelectContact(index);
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + 1 + "]")).Click();
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
