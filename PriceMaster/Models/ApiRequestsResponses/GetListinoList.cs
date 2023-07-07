using System.Text.Json.Serialization;

namespace PriceMaster.Models.ApiRequestsResponses
{
    public class ListDetails
    {
        [JsonPropertyName("DescrizioneProduttore")]
        public string DescrizioneProduttore { get; set; }

        [JsonPropertyName("DescrizioneProdotto")]
        public string DescrizioneProdotto { get; set; }

        [JsonPropertyName("DescrizioneCategoria")]
        public string DescrizioneCategoria { get; set; }

        [JsonPropertyName("DescrizioneSottocategoria")]
        public string DescrizioneSottocategoria { get; set; }

        [JsonPropertyName("Ean")]
        public string Ean { get; set; }

        [JsonPropertyName("ArticoloInternoCG")]
        public string ArticoloInternoCG { get; set; }

        [JsonPropertyName("ArticoloFornitore")]
        public string ArticoloFornitore { get; set; }

        [JsonPropertyName("DescrizioneArticolo")]
        public string DescrizioneArticolo { get; set; }

        [JsonPropertyName("RichiediQuotazione")]
        public string RichiediQuotazione { get; set; }

        [JsonPropertyName("Status")]
        public string Status { get; set; }

        [JsonPropertyName("MinimoVendibile")]
        public string MinimoVendibile { get; set; }

        [JsonPropertyName("PrezzoESP")]
        public string PrezzoESP { get; set; }

        [JsonPropertyName("PrezzoVendita")]
        public string PrezzoVendita { get; set; }

        [JsonPropertyName("PresenteBundle")]
        public string PresenteBundle { get; set; }

        [JsonPropertyName("PresentePromoFasce")]
        public string PresentePromoFasce { get; set; }

        [JsonPropertyName("TipoPromozione")]
        public string TipoPromozione { get; set; }

        [JsonPropertyName("DataInizioPromozione")]
        public string DataInizioPromozione { get; set; }

        [JsonPropertyName("DataFinePromozione")]
        public string DataFinePromozione { get; set; }

        [JsonPropertyName("QuantitaPromozione")]
        public string QuantitaPromozione { get; set; }

        [JsonPropertyName("SIAE")]
        public string SIAE { get; set; }

        [JsonPropertyName("DispoImmediata")]
        public string DispoImmediata { get; set; }

        [JsonPropertyName("DispoFutura")]
        public string DispoFutura { get; set; }

        [JsonPropertyName("SchedaTecnica")]
        public string SchedaTecnica { get; set; }

        [JsonPropertyName("Immagini")]
        public string Immagini { get; set; }
    }

    public class GetListinoListResponse
    {
        [JsonPropertyName("Articoli")]
        public List<ListDetails> Articoli { get; set; }
    }
}
