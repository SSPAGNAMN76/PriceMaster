using System.Text.Json.Serialization;

namespace PriceMaster.Models.ApiRequestsResponses
{
    public class ItemPriceDetails
    {
        [JsonPropertyName("CodiceFornitore")]
        public string CodiceFornitore { get; set; }

        [JsonPropertyName("CodiceInternoCG")]
        public string CodiceInternoCG { get; set; }

        [JsonPropertyName("PrezzoEsposto")]
        public int PrezzoEsposto { get; set; }

        [JsonPropertyName("PrezzoVendita")]
        public int PrezzoVendita { get; set; }

        [JsonPropertyName("TipoPromo")]
        public string TipoPromo { get; set; }

        [JsonPropertyName("DataInizioPromo")]
        public int DataInizioPromo { get; set; }

        [JsonPropertyName("DataFinePromo")]
        public int DataFinePromo { get; set; }

        [JsonPropertyName("DisponibilitaImmediata")]
        public int DisponibilitaImmediata { get; set; }

        [JsonPropertyName("DisponibilitaFutura")]
        public int DisponibilitaFutura { get; set; }

        [JsonPropertyName("CodiceEan")]
        public string CodiceEan { get; set; }

        [JsonPropertyName("Descrizione")]
        public string Descrizione { get; set; }

        [JsonPropertyName("RichiediQuotazione")]
        public string RichiediQuotazione { get; set; }

        [JsonPropertyName("Status")]
        public string Status { get; set; }

        [JsonPropertyName("MinimoVendibile")]
        public int MinimoVendibile { get; set; }

        [JsonPropertyName("PresentePromoAFasce")]
        public string PresentePromoAFasce { get; set; }

        [JsonPropertyName("QtaInPromo")]
        public int QtaInPromo { get; set; }

        [JsonPropertyName("Siae")]
        public int Siae { get; set; }
    }

    public class GetPriceListResponse
    {
        [JsonPropertyName("Articoli")]
        public List<ItemPriceDetails> Articoli { get; set; }
    }

}
