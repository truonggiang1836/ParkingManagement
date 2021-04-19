using Newtonsoft.Json;

namespace ParkingMangement.Model
{
    class Revenue
    {
        [JsonProperty("requestType")]
        public string RequestType { get; set; }
        [JsonProperty("MaCaTruc")]
        public string MaCaTruc { get; set; }
        [JsonProperty("NhanVien")]
        public string NhanVien { get; set; }
        [JsonProperty("GioBatDau")]
        public string GioBatDau { get; set; }
        [JsonProperty("GioKetThuc")]
        public string GioKetThuc { get; set; }
        [JsonProperty("TongXeVao")]
        public string TongXeVao { get; set; }
        [JsonProperty("TongXeRa")]
        public string TongXeRa { get; set; }
        [JsonProperty("TongXeTon")]
        public string TongXeTon { get; set; }
        [JsonProperty("TongTien")]
        public string TongTien { get; set; }
        [JsonProperty("SoLuotXe")]
        public RevenueDetail SoLuotXe { get; set; }
    }
}
