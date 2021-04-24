using Newtonsoft.Json;

namespace ParkingMangement.Model
{
    class RevenueDetail
    {
        [JsonProperty("LoaiThe")]
        public string LoaiThe { get; set; }
        [JsonProperty("SoXeVao")]
        public long SoXeVao { get; set; }
        [JsonProperty("SoXeRa")]
        public long SoXeRa { get; set; }
        [JsonProperty("SoXeTon")]
        public long SoXeTon { get; set; }
        [JsonProperty("SoTien")]
        public long SoTien { get; set; }
    }
}
