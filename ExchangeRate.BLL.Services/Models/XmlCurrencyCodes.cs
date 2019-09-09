using ExchangeRate.BLL.Services.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ExchangeRate.BLL.Services.Models
{
    [XmlRoot("Valuta")]
    public class XmlCurrencyCodes : IXmlModel
    {
        [XmlElement("Item")]
        public List<Valute> CurrencyCodes { get; set; }
    }

    [XmlRoot("ValCurs")]
    public class ValCurs : IXmlModel
    {
        [XmlElement("Record")]
        public List<Record> Records{ get; set; }
    }
}
