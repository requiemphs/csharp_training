using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager) : 
            base(manager)
        {
        }

        public ContactHelper Remove(int p)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(p);
            RemoveContact();
            ConfirmRemoveContact();
            return this;
        }

        public ContactHelper Remove(ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(contact.Id);
            RemoveContact();
            ConfirmRemoveContact();
            return this;
        }

        public ContactHelper Modify(int p, ContactData newData)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(p);
            FillContactForm(newData);
            SubmitContactModification();
            return this;
        }

        public ContactHelper Modify(ContactData contact, ContactData newData)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(contact.Id);
            FillContactForm(newData);
            SubmitContactModification();
            return this;
        }

        public ContactHelper Create(ContactData contact)
        {
            InitNewContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }
        // modification Barancev style

        public void InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
        }

        public ContactHelper InitContactModification(String id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value = '" + id + "'])")).FindElement(By.XPath("(//img[@alt='Edit'])")).Click();
            return this;
        }

        public void InitContactDetails(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
        }

        //public ContactHelper InitContactModification(int index)
        //{
        //    driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (index+1) + "]")).Click();
        //    return this;
        //}

        public ContactHelper ConfirmRemoveContact()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SelectContact(int index)
        {

            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }

        public ContactHelper SelectContact(String id)
        {

            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value = '"+id+"'])")).Click();
            return this;
        }

        public void CheckContactCreated()
        {
            if (ContactCreated())
            {
                return;
            }
            manager.Navigator.GoToHomePage();
            Create(new ContactData("Neew", "Teew"));
        }
        public bool ContactCreated()
        {
            return IsElementPresent(By.Name ("selected[]"));
        }

        public ContactHelper InitNewContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.Home);
            Type(By.Name("mobile"), contact.Mobile);
            Type(By.Name("work"), contact.Work);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);
            Type(By.Name("byear"), contact.Byear);
            Type(By.Name("ayear"), contact.Ayear);
            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("phone2"), contact.Phone2);
            Type(By.Name("notes"), contact.Notes);

            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText("-");
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText("-");
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText("-");
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText("-");
            return this;
        }


        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
            return this;
        }

        private List<ContactData> contactCache = null;
        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {
                    var tds = element.FindElements(By.CssSelector("td"));
                    contactCache.Add(new ContactData(tds[2].Text, tds[1].Text)
                    {
                        Id = tds[0].FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
            return new List<ContactData>(contactCache);
        }

        public int GetContactCount()
        {
            manager.Navigator.GoToHomePage();
            return driver.FindElements(By.Name("entry")).Count;
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(0);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value");

            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email1 = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Company = company,
                Title = title,
                Nickname = nickName,
                Middlename = middleName,
                Address = address,
                Fax = fax,
                Home = homePhone,
                Mobile = mobilePhone,
                Work = workPhone,
                Email = email1,
                Email2 = email2,
                Email3 = email3,
            };
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails 
            };
        }

        public ContactData GetContactInformationFromDetails()
        {
            manager.Navigator.GoToHomePage();
            InitContactDetails(0);
            var allInformation = driver.FindElement(By.Id("content")).Text;
            return new ContactData()
            {
                AllInformation  = allInformation
            };
        }

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m =  new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }

        public void AddContactToGroup(ContactData contact, GroupData @group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            SelectContact(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => driver.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        public void SelectGroupToAdd(string groupName)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(groupName);
        }
        //public void SelectContact(string contactId)
        //{
        //    driver.FindElement(By.Id(contactId)).Click();
        //}
        public void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }
    }
}
