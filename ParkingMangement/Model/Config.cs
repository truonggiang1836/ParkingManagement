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

        [XmlElement(ElementName = "camera_car_url_1")]
        public string cameraCarUrl1 { get; set; } = "";

        [XmlElement(ElementName = "camera_car_url_2")]
        public string cameraCarUrl2 { get; set; } = "";

        [XmlElement(ElementName = "camera_car_url_3")]
        public string cameraCarUrl3 { get; set; } = "";

        [XmlElement(ElementName = "camera_car_url_4")]
        public string cameraCarUrl4 { get; set; } = "";

        [XmlElement(ElementName = "rfid_in")]
        public string rfidIn { get; set; } = "";

        [XmlElement(ElementName = "rfid_out")]
        public string rfidOut { get; set; } = "";

        [XmlElement(ElementName = "rfid_car_in")]
        public string rfidCarIn { get; set; } = "";

        [XmlElement(ElementName = "rfid_car_out")]
        public string rfidCarOut { get; set; } = "";

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
        public float ZoomCamera1 { get; set; } = 50;

        [XmlElement(ElementName = "zoom_camera_2")]
        public float ZoomCamera2 { get; set; } = 50;

        [XmlElement(ElementName = "zoom_camera_3")]
        public float ZoomCamera3 { get; set; } = 50;

        [XmlElement(ElementName = "zoom_camera_4")]
        public float ZoomCamera4 { get; set; } = 50;
        [XmlElement(ElementName = "zoom_camera_car_1")]
        public float ZoomCameraCar1 { get; set; } = 50;

        [XmlElement(ElementName = "zoom_camera_car_2")]
        public float ZoomCameraCar2 { get; set; } = 50;

        [XmlElement(ElementName = "zoom_camera_car_3")]
        public float ZoomCameraCar3 { get; set; } = 50;

        [XmlElement(ElementName = "zoom_camera_car_4")]
        public float ZoomCameraCar4 { get; set; } = 50;

        [XmlElement(ElementName = "com_receive_in")]
        public string comReceiveIn { get; set; } = "";

        [XmlElement(ElementName = "com_receive_out")]
        public string comReceiveOut { get; set; } = "";

        [XmlElement(ElementName = "com_reader_left")]
        public string comReaderLeft { get; set; } = "";

        [XmlElement(ElementName = "com_reader_right")]
        public string comReaderRight { get; set; } = "";

        [XmlElement(ElementName = "com_reader_car_left")]
        public string comReaderCarLeft { get; set; } = "";

        [XmlElement(ElementName = "com_reader_car_right")]
        public string comReaderCarRight { get; set; } = "";

        [XmlElement(ElementName = "com_send")]
        public string comSend { get; set; } = "";

        [XmlElement(ElementName = "com_led_left")]
        public string comLedLeft { get; set; } = "";

        [XmlElement(ElementName = "com_led_right")]
        public string comLedRight { get; set; } = "";

        [XmlElement(ElementName = "read_digit_left_lane")]
        public string readDigitLeftLane { get; set; } = "2";

        [XmlElement(ElementName = "read_digit_right_lane")]
        public string readDigitRightLane { get; set; } = "4";

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
        public string readDigitFolder { get; set; } = "HINH_BIEN_SO";
      
        [XmlElement(ElementName = "project_id")]
        public string projectId { get; set; } = "";
        [XmlElement(ElementName = "signature")]
        public string signature { get; set; } = "";
        [XmlElement(ElementName = "is_include_min_minute")]
        public string isIncludeMinMinute { get; set; } = "yes";
        [XmlElement(ElementName = "is_use_lost_available_led")]
        public string isUseLostAvailableLed { get; set; } = "yes";
        [XmlElement(ElementName = "backup_computer_name")]
        public string backupComputerName { get; set; } = "";
    }
}
