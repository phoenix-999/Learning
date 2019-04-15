using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
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


            AddBook(xmlDocument, "novel", "1-861001-45-5", DateTime.Now, "Test", 50.00);


            foreach (string book in SelectBooks(xmlDocument, DateTime.Now))
            {
                Console.WriteLine(book);
            }

            Console.WriteLine("\n\n {0}", xmlDocument.InnerXml);
        }

        static void InitXmlDocument()
        {
            xmlDocument = new XmlDocument();
            try
            {
                xmlDocument.Load(DOCUMENT_NAME);
            }
            catch(FileNotFoundException)
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

        //static void AddBook(XmlDocument doc, string genre, string isbn, DateTime publicationdate, string title, double price)
        //{
        //    XPathNavigator navigator = doc.CreateNavigator();

        //    string ns = doc.DocumentElement.NamespaceURI;
        //    navigator.MoveToFollowing("book", ns);

        //    using (XmlWriter writer = navigator.InsertBefore())
        //    { 
        //        writer.WriteStartElement("book");
        //        writer.WriteAttributeString("genre", genre);
        //        writer.WriteAttributeString("ISBN", isbn);
        //        writer.WriteAttributeString("publicationdate", publicationdate.ToShortDateString());
        //            writer.WriteStartElement("title");
        //            writer.WriteValue(title);
        //            writer.WriteEndElement();
        //            writer.WriteStartElement("price");
        //            writer.WriteValue(price.ToString());
        //            writer.WriteEndElement();
        //        writer.WriteEndElement();

        //    }

        //    doc.Save(DOCUMENT_NAME);
        //}


        //Более простой способ добавления элемента
        static void AddBook(XmlDocument doc, string genre, string isbn, DateTime publicationdate, string title, double price)
        {
            XmlElement book = doc.CreateElement("book");

            book.SetAttribute("genre", genre);
            book.SetAttribute("ISBN", isbn);
            book.SetAttribute("publicationdate", publicationdate.ToShortDateString());

            XmlElement bookTitle = doc.CreateElement("title");
            bookTitle.InnerText = title;
            book.AppendChild(bookTitle);

            XmlElement bookPrice = doc.CreateElement("price");
            bookPrice.InnerText = price.ToString();
            book.AppendChild(bookPrice);

            doc.DocumentElement.AppendChild(book);

            doc.Save(DOCUMENT_NAME);
        }

        static IEnumerable<string> SelectBooks(XmlDocument doc, DateTime publicationdate)
        {
            List<string> result = new List<string>();

            foreach (XmlNode node in doc.GetElementsByTagName("book"))
            {
                if (node.Attributes["publicationdate"].Value == publicationdate.ToShortDateString())
                {
                    result.Add(node.FirstChild.InnerText);
                }
            }


            
            // Не работает Select. Вариант реализации выше - компактней и работает
            //XPathNavigator navigator = doc.CreateNavigator();

            //С какого-то хера не возвращает ничего
            //XPathNodeIterator iterator = navigator.Select("books/book");

            //while(iterator.MoveNext())
            //{
            //    XPathNavigator bookNavigator = iterator.Current;

            //    bookNavigator.MoveToAttribute("publicationdate", "");

            //    if (bookNavigator.Value == publicationdate.ToShortDateString())
            //    {
            //        bookNavigator.MoveToChild("title", "");
            //        result.Add(bookNavigator.Value);
            //    }
            //}


            return result;
        }

    }
}
