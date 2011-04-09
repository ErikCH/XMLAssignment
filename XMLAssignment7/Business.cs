// By: Erik Hanchett
// Date:4/09/2011
// Assignment: #7
// 

// This is the main Business class. It has all the methods for all the tasks. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace XMLAssignment7
{
    public class Business
    {
        //properties
        public const string FILE_NAME = "XML/DailyDrop.xml";
        public const string FILE_NAME_T2 = "DailyDropT2.xml";
        public const string NET_TAG = "netInOut";
        public const string BANK_TAG = "bank";
        public const string IN_V = "dollarsIn";
        public const string OUT_V = "dollarsOut";
        public const string XPATH_IN_V = "machine/dollarsIn";
        public const string XPATH_OUT_V = "machine/dollarsOut";
        private XmlReader reader;
        private XmlWriter writer;
        private XmlDocument doc;

        //constructor
        public Business()
        {
            writer = XmlWriter.Create(FILE_NAME_T2);
        }


        public string Task1()
        {
            reader = XmlReader.Create(FILE_NAME);
            decimal in_v = 0;
            decimal out_v = 0;
            while (reader.Read()) 
            {
                if (reader.IsStartElement())
                {
                    switch (reader.Name)
                    {
                        case IN_V:
                            if(reader.Read())
                                in_v += Convert.ToDecimal(reader.Value.Trim());
                            break;
                        case OUT_V:
                            if (reader.Read())
                                out_v += Convert.ToDecimal(reader.Value.Trim());
                            break;
                    }
                }
            }
            reader.Close();
            return IN_V + in_v.ToString() + "\n" + OUT_V + out_v.ToString();

        }

        public void Task2()
        {
                reader = XmlReader.Create(FILE_NAME);
                decimal in_v=0;
                decimal out_v=0;
               
                while (reader.Read())
                {
                    if (reader.Name == IN_V )
                    {
                        if (reader.Read() && reader.NodeType == XmlNodeType.Text)
                                in_v = Convert.ToDecimal(reader.Value.Trim());
                            
                        
                           
                    }
                    else if (reader.Name == OUT_V)
                    {
                        
                        
                            if (reader.Read() && reader.NodeType == XmlNodeType.Text)
                            {
                                out_v = Convert.ToDecimal(reader.Value.Trim());
                                writer.WriteElementString(NET_TAG, (in_v - out_v).ToString());
                            }
                               
                            
                           

                        
                    }
                    else PassNodeThrough(reader, writer);
                }
                
                reader.Close();
                writer.Close();
                
            
        }

        public string Task3()
        {
            doc = new XmlDocument();
            doc.Load(XmlReader.Create(FILE_NAME));
            return doc.GetElementsByTagName(BANK_TAG).Count.ToString();
        }

        public string Task4()
        {
            decimal totalIn = 0;
            decimal totalOut = 0;
            string temp = "";
            int count = 1;

            doc = new XmlDocument();
            doc.Load(XmlReader.Create(FILE_NAME));
            XmlNodeList nodes = doc.GetElementsByTagName(BANK_TAG);
            foreach(XmlNode node in nodes)
            {
                
                totalIn = 0;
                totalOut = 0;
                XmlNodeList nodesIN = node.SelectNodes(XPATH_IN_V);
                XmlNodeList nodesOut = node.SelectNodes(XPATH_OUT_V);

                foreach (XmlNode nodeIN in nodesIN)
                    totalIn += Convert.ToDecimal(nodeIN.InnerText);

                foreach (XmlNode nodeOut in nodesOut)
                    totalOut += Convert.ToDecimal(nodeOut.InnerText);

                temp += "\n" + BANK_TAG + " " + count + " " +IN_V + " " +  ": " + " " + totalIn;
                temp += "\n" + BANK_TAG + " " + count + " " + OUT_V + " " + ": " + " " + totalOut;
                count++;
            }
            return temp;
        }

        //This is basically the same as 4 accept now I'm aggregating each bank.
        public string Task5()
        {
            decimal totalIn = 0;
            decimal totalOut = 0;
            string temp = "";
            int count = 1;

            doc = new XmlDocument();
            doc.Load(XmlReader.Create(FILE_NAME));
            XmlNodeList nodes = doc.GetElementsByTagName(BANK_TAG);
            foreach (XmlNode node in nodes)
            {

                totalIn = 0;
                totalOut = 0;
                XmlNodeList nodesIN = node.SelectNodes(XPATH_IN_V);
                XmlNodeList nodesOut = node.SelectNodes(XPATH_OUT_V);

                foreach (XmlNode nodeIN in nodesIN)
                    totalIn += Convert.ToDecimal(nodeIN.InnerText);

                foreach (XmlNode nodeOut in nodesOut)
                    totalOut += Convert.ToDecimal(nodeOut.InnerText);

                temp += "\n" + BANK_TAG + " " + count + " " + IN_V + " " + ": " + " " + (totalIn - totalOut);
                
                count++;
            }
            return temp;
        }


        //copies from example
        private void PassNodeThrough(XmlReader reader, XmlWriter writer)
        {
            switch (reader.NodeType)
            {
                case XmlNodeType.Element:
                    writer.WriteStartElement(reader.Prefix, reader.LocalName, reader.NamespaceURI);
                    writer.WriteAttributes(reader, true);
                    if (reader.IsEmptyElement)
                    {
                        writer.WriteEndElement();
                    }
                    break;

                case XmlNodeType.Text:
                    writer.WriteString(reader.Value);
                    break;

                case XmlNodeType.Whitespace:
                case XmlNodeType.SignificantWhitespace:
                    writer.WriteWhitespace(reader.Value);
                    break;

                case XmlNodeType.CDATA:
                    writer.WriteCData(reader.Value);
                    break;

                case XmlNodeType.EntityReference:
                    writer.WriteEntityRef(reader.Name);
                    break;

                case XmlNodeType.XmlDeclaration:
                case XmlNodeType.ProcessingInstruction:
                    writer.WriteProcessingInstruction(reader.Name, reader.Value);
                    break;

                case XmlNodeType.DocumentType:
                    writer.WriteDocType(reader.Name, reader.GetAttribute("PUBLIC"), reader.GetAttribute("SYSTEM"), reader.Value);
                    break;

                case XmlNodeType.Comment:
                    writer.WriteComment(reader.Value);
                    break;

                case XmlNodeType.EndElement:
                    writer.WriteFullEndElement();
                    break;
            }
        }
    }
}
