using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CSharpLB5.Service
{
    public class Logger
    {
        private XmlWriter _writer;
        public Logger(string filePath)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;
            _writer = XmlWriter.Create(filePath, settings);
            _writer.WriteStartElement("log");
        }

        public void Log(string message)
        {
            _writer.WriteStartElement("entry");
            _writer.WriteAttributeString("timestamp", DateTime.Now.ToString());
            _writer.WriteString(message);
            _writer.WriteEndElement();
        }

        public void Close()
        {
            _writer.WriteEndElement();
            _writer.Close();
        }
    }
}
