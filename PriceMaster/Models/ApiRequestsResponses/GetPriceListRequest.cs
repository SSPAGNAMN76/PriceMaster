using System.Text.Json.Serialization;

namespace PriceMaster.Models.ApiRequestsResponses
{
    public class GetPriceListRequest
    {
        [JsonPropertyName("Articoli")]
        public List<string> Articoli { get; set; }
    }
}
