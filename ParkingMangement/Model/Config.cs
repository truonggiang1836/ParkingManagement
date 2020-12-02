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
        public string cameraUrl1 { get; set; } = "";

        [XmlElement(ElementName = "camera_url_2")]
        public string cameraUrl2 { get; set; } = "";

        [XmlElement(ElementName = "camera_url_3")]
        public string cameraUrl3 { get; set; } = "";

        [XmlElement(ElementName = "camera_url_4")]
        public string cameraUrl4 { get; set; } = "";

        [XmlElement(ElementName = "rfid_in")]
        public string rfidIn { get; set; } = "";

        [XmlElement(ElementName = "rfid_out")]
        public string rfidOut { get; set; } = "";

        [XmlElement(ElementName = "computer_name")]
        public string computerName { get; set; } = "";

        [XmlElement(ElementName = "sql_datasource")]
        public string sqlDataSource { get; set; } = "";

        [XmlElement(ElementName = "sql_port")]
        public string sqlPort { get; set; } = "";

        [XmlElement(ElementName = "sql_username")]
        public string sqlUsername { get; set; } = "";

        [XmlElement(ElementName = "sql_password")]
        public string sqlPassword { get; set; } = "";

        [XmlElement(ElementName = "folder_root")]
        public string folderRoot { get; set; } = "";

        [XmlElement(ElementName = "last_saved_order")]
        public string lastSavedOrder { get; set; } = "";

        [XmlElement(ElementName = "in_out_type")]
        public int inOutType { get; set; } = 1;

        [XmlElement(ElementName = "zoom_camera_1")]
        public int ZoomCamera1 { get; set; } = 30;

        [XmlElement(ElementName = "zoom_camera_2")]
        public int ZoomCamera2 { get; set; } = 30;

        [XmlElement(ElementName = "zoom_camera_3")]
        public int ZoomCamera3 { get; set; } = 30;

        [XmlElement(ElementName = "zoom_camera_4")]
        public int ZoomCamera4 { get; set; } = 30;

        [XmlElement(ElementName = "com_receive_in")]
        public string comReceiveIn { get; set; } = "";

        [XmlElement(ElementName = "com_receive_out")]
        public string comReceiveOut { get; set; } = "";

        [XmlElement(ElementName = "com_send")]
        public string comSend { get; set; } = "";

        [XmlElement(ElementName = "com_led_left")]
        public string comLedLeft { get; set; } = "";

        [XmlElement(ElementName = "com_led_right")]
        public string comLedRight { get; set; } = "";

        [XmlElement(ElementName = "com_lost_available")]
        public string comLostAvailable { get; set; } = "";

        [XmlElement(ElementName = "signal_open_barie_in")]
        public string signalOpenBarieIn { get; set; } = "";

        [XmlElement(ElementName = "signal_close_barie_in")]
        public string signalCloseBarieIn { get; set; } = "";

        [XmlElement(ElementName = "signal_open_barie_out")]
        public string signalOpenBarieOut { get; set; } = "";

        [XmlElement(ElementName = "signal_close_barie_out")]
        public string signalCloseBarieOut { get; set; } = "";

        [XmlElement(ElementName = "signal_open_barie_in_motorbike")]
        public string signalOpenBarieInMotorbike { get; set; } = "";

        [XmlElement(ElementName = "signal_close_barie_in_motorbike")]
        public string signalCloseBarieInMotorbike { get; set; } = "";

        [XmlElement(ElementName = "signal_open_barie_out_motorbike")]
        public string signalOpenBarieOutMotorbike { get; set; } = "";

        [XmlElement(ElementName = "signal_close_barie_out_motorbike")]
        public string signalCloseBarieOutMotorbike { get; set; } = "";

        [XmlElement(ElementName = "uhf_query_time")]
        public double uhfQueryTime { get; set; } = 1;

        [XmlElement(ElementName = "is_using_uhf")]
        public string isUsingUhf { get; set; } = "no";

        [XmlElement(ElementName = "read_digit_folder")]
        public string readDigitFolder { get; set; } = "";
      
        [XmlElement(ElementName = "project_id")]
        public string projectId { get; set; } = "";
        [XmlElement(ElementName = "python_folder")]
        public string pythonFolder { get; set; } = "";
        [XmlElement(ElementName = "python_run_file")]
        public string pythonRunFile { get; set; } = "";
        [XmlElement(ElementName = "python_server_url")]
        public string pythonServerUrl { get; set; } = "";
        [XmlElement(ElementName = "is_use_cost_deposit")]
        public string isUseCostDeposit { get; set; } = "yes";
    }
}
