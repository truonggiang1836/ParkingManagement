using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ParkingMangement.Model
{
    [Serializable()]
    [XmlRoot("xml")]
    public class Config
    {
        [XmlElement(ElementName = "camera_url_1")]
        public string cameraUrl1 { get; set; }

        [XmlElement(ElementName = "camera_url_3")]
        public string cameraUrl3 { get; set; }
    }
}
