using Newtonsoft.Json;

namespace ParkingMangement.Model
{
    class RevenueDetail
    {
        [JsonProperty("LoaiThe")]
        public string LoaiThe { get; set; }
        [JsonProperty("SoXeVao")]
        public string SoXeVao { get; set; }
        [JsonProperty("SoXeRa")]
        public string SoXeRa { get; set; }
        [JsonProperty("SoXeTon")]
        public string SoXeTon { get; set; }
        [JsonProperty("SoTien")]
        public string SoTien { get; set; }
    }
}
