using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ExchangeRate.BLL.Services.Models
{
    public class Valute
    {
        [XmlElement("EngName")]
        public string Name { get; set; }
        [XmlElement("ParentCode")]
        public string Code { get; set; }
        [XmlElement("Nominal")]
        public int Nominal { get; set; }
    }

    public class Record
    {
        [XmlAttribute("Date")]
        public string Date { get; set; }
        [XmlElement("Value")]
        public string Value { get; set; }
    }
}
