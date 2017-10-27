using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allInformation;
        private string allPhonesWithLetters;
        private string rnAllEmails;
        private string fullName;

        public ContactData()
        {

        }

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }



        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode() ^ Lastname.GetHashCode();
        }

        public override string ToString()
        {
            return "firstname = " + Firstname + 
                "\nlastname = " + Lastname + 
                "\naddress = " + Address + 
                "\nhomephone = " + Home +
                "\nmobilephone = " + Mobile +
                "\nemail = " + Email; 
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Lastname.CompareTo(other.Lastname);
        }

        [Column(Name = "firstname")]
        public string Firstname{ get; set; }

        [Column(Name = "lastname")]
        public string Lastname { get; set; }

        [Column(Name = "middlename")]
        public string Middlename { get; set; }

        public string FullName
        {
            get
            {
                if (fullName != null)
                {
                    return fullName;
                }
                else
                {
                    return CleanUpFullName(Firstname) + CleanUpFullName(Middlename) + CleanUpFullName(Lastname).Trim();
                }
            }
            set { fullName = value; }
        }
        private string CleanUpFullName(string fullName)
        {
            if (fullName == null || fullName == "")
            {
                return "";
            }
            return fullName + " ";
        }

        [Column(Name = "nickname")]
        public string Nickname { get; set; }

        [Column(Name = "title")]
        public string Title { get; set; }

        [Column(Name = "company")]
        public string Company { get; set; }

        [Column(Name = "address")]
        public string Address { get; set; }

        [Column(Name = "home")]
        public string Home { get; set; }

        [Column(Name = "mobile")]
        public string Mobile { get; set; }

        [Column(Name = "work")]
        public string Work { get; set; }

        [Column(Name = "fax")]
        public string Fax { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {

                    return (CleanUpPhone(Home) + CleanUpPhone(Mobile) + CleanUpPhone(Work)).Trim();
                }
            }
            set { allPhones = value; }
        }

        private string CleanUpPhone(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }
        public string AllPhonesWithLetters
        {
            get
            {
                if (allPhonesWithLetters != null)
                {
                    return allPhonesWithLetters;
                }
                else
                {

                    return "\r\n" + CleanUpPhoneWithLetters("H: " + Home) 
                        + CleanUpPhoneWithLetters("M: " + Mobile) 
                        + CleanUpPhoneWithLetters("W: " + Work)
                        + CleanUpPhoneWithLetters("F: " + Fax).Trim();
                }
            }
            set { allPhonesWithLetters = value; }
        }
        private string CleanUpPhoneWithLetters(string phone)
        {

             if (string.IsNullOrEmpty(phone))
            {
                return "";
            }

            return phone + "\r\n";

        }

        [Column(Name = "email")]
        public string Email { get; set; }

        [Column(Name = "email2")]
        public string Email2 { get; set; }

        [Column(Name = "email3")]
        public string Email3 { get; set; }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return CleanUpEmail(Email) + CleanUpEmail(Email2) + CleanUpEmail(Email3).Trim();
                }
            }
            set { allEmails = value; }
        }

        private string CleanUpEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return  email + "\r\n";
        }

        public string RnAllEmails
        {
            get
            {
                if (rnAllEmails != null)
                {
                    return rnAllEmails;
                }
                else
                {
                    return "\r\n" + CleanUpEmails(Email) + CleanUpEmails(Email2) + CleanUpEmails(Email3).Trim();
                }
            }
            set { rnAllEmails = value; }
        }

        private string CleanUpEmails(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return email + "\r\n";
        }

        [Column(Name = "homepage")]
        public string Homepage { get; set; }

        [Column(Name = "byear")]
        public string Byear { get; set; }

        [Column(Name = "ayear")]
        public string Ayear { get; set; }

        [Column(Name = "address2")]
        public string Address2 { get; set; }

        [Column(Name = "phone2")]
        public string Phone2 { get; set; }

        [Column(Name = "notes")]
        public string Notes { get; set; }

        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public string AllInformation
        {
            get
            {
                if (allInformation != null)
                {
                    return allInformation;
                }
                else
                {
                    return (CleanAllInformation(FullName)
                           + CleanAllInformation(Nickname)
                           + CleanAllInformation(Title)
                           + CleanAllInformation(Company)
                           + CleanAllInformation(Address) 
                           + CleanAllInformation(AllPhonesWithLetters) 
                           + CleanAllInformation(RnAllEmails)).Trim();
                }
            }
            set { allInformation = value; }
        }
        private string CleanAllInformation(string allInformation)
        {
            if (allInformation == null || allInformation == "")
            {
                return "";
            }
            return allInformation + "\r\n";
        }

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }
        }
    }
}
