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

        [XmlElement(ElementName = "camera_url_2")]
        public string cameraUrl2 { get; set; }

        [XmlElement(ElementName = "camera_url_3")]
        public string cameraUrl3 { get; set; }

        [XmlElement(ElementName = "camera_url_4")]
        public string cameraUrl4 { get; set; }

        [XmlElement(ElementName = "rfid_in")]
        public string rfidIn { get; set; }

        [XmlElement(ElementName = "rfid_out")]
        public string rfidOut { get; set; }

        [XmlElement(ElementName = "computer_name")]
        public string computerName { get; set; }

        [XmlElement(ElementName = "sql_datasource")]
        public string sqlDataSource { get; set; }

        [XmlElement(ElementName = "sql_port")]
        public string sqlPort { get; set; }

        [XmlElement(ElementName = "sql_username")]
        public string sqlUsername { get; set; }

        [XmlElement(ElementName = "sql_password")]
        public string sqlPassword { get; set; }

        [XmlElement(ElementName = "folder_root")]
        public string folderRoot { get; set; }

        [XmlElement(ElementName = "last_saved_order")]
        public string lastSavedOrder { get; set; }

        [XmlElement(ElementName = "in_out_type")]
        public int inOutType { get; set; }
    }
}
