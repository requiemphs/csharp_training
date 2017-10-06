using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allInformation;
        private string allPhonesWithLetters;
        private string rnAllEmails;
        private string fullName;

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public ContactData()
        {
            AllInformation = allInformation;
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

        public string Firstname{ get; set; }
        public string Lastname { get; set; }
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
        public string Nickname { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
  
        public string Home { get; set; }
        public string Mobile { get; set; }
        public string Work { get; set; }
        public string Fax { get; set; }

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
        public string Email { get; set; }
        public string Email2 { get; set; }
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
        public string Homepage { get; set; }
        public string Byear { get; set; }
        public string Ayear { get; set; }
        public string Address2 { get; set; }
        public string Phone2 { get; set; }
        public string Notes { get; set; }
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
    }
}
