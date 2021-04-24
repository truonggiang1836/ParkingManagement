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
        public long TongXeVao { get; set; }
        [JsonProperty("TongXeRa")]
        public long TongXeRa { get; set; }
        [JsonProperty("TongXeTon")]
        public long TongXeTon { get; set; }
        [JsonProperty("TongTien")]
        public long TongTien { get; set; }
        [JsonProperty("SoLuotXe")]
        public string SoLuotXe { get; set; }
        [JsonProperty("SoLuotXeChiTiet")]
        public string SoLuotXeChiTiet { get; set; }
    }
}
