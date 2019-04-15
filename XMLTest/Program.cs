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
        static readonly string DOCUMENT_NAME = "te5st.xml";
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
                using (FileStream fs = new FileStream(DOCUMENT_NAME, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.Read))
                {
                    XmlTextWriter writer = new XmlTextWriter(fs, Encoding.Unicode);
                    writer.WriteStartDocument();
                    writer.Formatting = Formatting.Indented; //писать с переводом строки
                    writer.IndentChar = ' '; //писать с отступами
                    writer.Indentation = 4;
                    //writer.WriteWhitespace(Environment.NewLine);
                    writer.WriteStartElement("library");
                    writer.WriteStartElement("book");
                    writer.WriteValue("1");
                    writer.WriteEndElement();
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

            foreach (var node in doc.DocumentElement.ChildNodes)
            {
                XmlElement xmlElement;

                if (node is XmlElement) //В случае наличия текста между тегами вернется XmlText
                    xmlElement = node as XmlElement;
                else
                    continue;

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
