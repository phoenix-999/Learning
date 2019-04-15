using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;

namespace XMLTest
{
    class Program
    {
        static readonly string DOCUMENT_NAME = "test.xml";
        static XmlDocument xmlDocument;
        static void Main(string[] args)
        {
            InitXmlDocument();
            WriteRootXmlElement(xmlDocument);

            XmlElement elemet = GetBook(xmlDocument, "1 - 861002 - 30 - 1");
            if (elemet != null)
            {
                foreach (XmlAttribute attr in elemet.Attributes)
                {
                    Console.WriteLine("Attribute: {0}, value: {1}", attr.LocalName, attr.Value);
                }
                AddBookmark(elemet, "first", 1);
            }
            else
            {
                Console.WriteLine("Book {0} not found", "1 - 861002 - 30 - 1");
            }

            

            Console.WriteLine(xmlDocument.InnerXml);
        }

        static void InitXmlDocument()
        {
            xmlDocument = new XmlDocument();
            try
            {
                xmlDocument.Load(DOCUMENT_NAME);
            }
            catch(Exception)
            {
                using (FileStream fs = new FileStream(DOCUMENT_NAME, FileMode.Create, FileAccess.ReadWrite, FileShare.Read))
                {
                    XmlTextWriter writer = new XmlTextWriter(fs, Encoding.UTF8);
                    writer.WriteStartDocument();
                    writer.WriteWhitespace(Environment.NewLine);
                    writer.WriteStartElement("library");
                    writer.WriteEndElement();
                    writer.Close();
                }

                xmlDocument.Load(DOCUMENT_NAME);
            }
        }

        static void WriteRootXmlElement(XmlDocument doc)
        {
            Console.WriteLine(doc.DocumentElement.OuterXml);
        }

        static XmlElement GetBook(XmlDocument doc, string isbn)
        {
            XmlElement result = null;

            string pattern = @" ";
            isbn = Regex.Replace(isbn, pattern, "");

            foreach (XmlElement xmlElement in doc.DocumentElement.ChildNodes)
            {
                string attrValue = xmlElement.GetAttribute("ISBN");
                if (attrValue == isbn)
                {
                    result = xmlElement;
                }
                    
            }

            return result;
        }

        static void AddBookmark(XmlElement book, string bookmarkName, int pageNumber)
        {
            XmlElement bookmark = book.OwnerDocument.CreateElement("bookmark", book.NamespaceURI);
            bookmark.SetAttribute(bookmarkName, pageNumber.ToString());

            book.AppendChild(bookmark);

            book.OwnerDocument.Save(DOCUMENT_NAME);
        }
    }
}
