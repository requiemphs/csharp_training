using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using WebAddressbookTests;
using Formatting = Newtonsoft.Json.Formatting;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            string datatype = args[0];
            int count = Convert.ToInt32(args[1]);
            StreamWriter writer = new StreamWriter(args[2]);
            string format = args[3];

            if (datatype == "g")
            { 

            List<GroupData> groups = new List<GroupData>(); 
            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                {
                    Header = TestBase.GenerateRandomString(10),
                    Footer = TestBase.GenerateRandomString(10)
                });

            }
            
            if (format == "csv")
            {
                WriteGroupsToCsvFile(groups, writer);
            }
            else if (format == "xml")
            {
                WriteGroupsToJsonFile(groups, writer);
            }
            else if (format == "json")
            {
                WriteGroupsToJsonFile(groups, writer);
            }
            else
            {
                System.Console.Out.Write("Unrecognized format" + format);
            }
            writer.Close();
            }

            else if (datatype == "c")
            {
                List<ContactData> contacts = new List<ContactData>();
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10))
                    {
                        Address = TestBase.GenerateRandomString(10),
                        Home = TestBase.GenerateRandomString(9),
                        Mobile = TestBase.GenerateRandomString(9),
                        Email = TestBase.GenerateRandomString(9)
                    });

                }
                if (format == "xml")
                {
                    WriteContactsToJsonFile(contacts, writer);
                }
                else if (format == "json")
                {
                    WriteContactsToJsonFile(contacts, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized format" + format);
                }
                writer.Close();
            }

            else
            {
                System.Console.Out.Write("Unrecognized datatype" + datatype);
            }
            writer.Close();
        }
         



        static void WriteGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
        }

        static void WriteGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void WriteGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented ));
        }

        static void WriteContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, contacts);
        }

        static void WriteContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
