using NuGet.Protocol.Core.Types;
using System.Text.Json.Serialization;

namespace PriceMaster.Models.ApiRequestsResponses
{
    public class Ddt
    {
        public Ddt()
        {
            TipoDocumento = string.Empty;
            Righe = new List<Righe>();
            LinkTracking = string.Empty;
            CapDestinazione = string.Empty;
            LocalitaDestinazione = string.Empty;
            IndirizzoDestinazione = string.Empty;
            RagioneSocialeDestinazione = string.Empty;
            Note = string.Empty;
            RiferimentoOrdineBP = string.Empty;
            RiferimentoOrdineCG = string.Empty;


        }


        [JsonPropertyName("AnnoDocumento")]
        public int AnnoDocumento { get; set; }

        [JsonPropertyName("TipoDocumento")]
        public string TipoDocumento { get; set; }

        [JsonPropertyName("NumeroDocumento")]
        public int NumeroDocumento { get; set; }

        [JsonPropertyName("DataDocumento")]
        public int DataDocumento { get; set; }

        [JsonPropertyName("CodiceClienteCG")]
        public int CodiceClienteCG { get; set; }

        [JsonPropertyName("RiferimentoOrdineCG")]
        public string RiferimentoOrdineCG { get; set; }

        [JsonPropertyName("DataOrdineCG")]
        public int DataOrdineCG { get; set; }

        [JsonPropertyName("RiferimentoOrdineBP")]
        public string RiferimentoOrdineBP { get; set; }

        [JsonPropertyName("DataOrdineBP")]
        public int DataOrdineBP { get; set; }

        [JsonPropertyName("Note")]
        public string Note { get; set; }

        [JsonPropertyName("RagioneSocialeDestinazione")]
        public string RagioneSocialeDestinazione { get; set; }

        [JsonPropertyName("IndirizzoDestinazione")]
        public string IndirizzoDestinazione { get; set; }

        [JsonPropertyName("CapDestinazione")]
        public string CapDestinazione { get; set; }

        [JsonPropertyName("LocalitaDestinazione")]
        public string LocalitaDestinazione { get; set; }

        [JsonPropertyName("LinkTracking")]
        public string LinkTracking { get; set; }

        [JsonPropertyName("Righe")]
        public List<Righe> Righe { get; set; }
    }

    public class Righe
    {
        public Righe()
        {
            Matricole = new List<string>();
            DescrizioneArticolo = string.Empty;
            Articolo = string.Empty;


        }

        [JsonPropertyName("RigaDocumento")]
        public int RigaDocumento { get; set; }

        [JsonPropertyName("Articolo")]
        public string Articolo { get; set; }

        [JsonPropertyName("DescrizioneArticolo")]
        public string DescrizioneArticolo { get; set; }

        [JsonPropertyName("Quantita")]
        public int Quantita { get; set; }

        [JsonPropertyName("Matricole")]
        public List<string> Matricole { get; set; }
    }

    public class GetDDTResponse
    {
        public GetDDTResponse()
        {
            Ddt = new List<Ddt>();
        }

        [JsonPropertyName("Ddt")]
        public List<Ddt> Ddt { get; set; }
    }


}
