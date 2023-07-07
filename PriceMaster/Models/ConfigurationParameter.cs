namespace PriceMaster.Models
{
    public class ConfigurationParameter
    {
        public int Id { get; set; }
        public decimal IVA { get; set; }
        public int ScortaMinima { get; set; }
        public decimal RicaricoMinimo { get; set; }
        public decimal SpeseSpedizioneListino { get; set; }
        public decimal MargineSSMinimo { get; set; }
        public decimal DifferenzaMinima { get; set; }
        public decimal SpeseSpedizioneRivenditore { get; set; }

        public DateTime ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public bool IsCurrent { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public bool IsValid(out List<string> validationErrors)
        {
            validationErrors = new List<string>();

            if (IVA <= 0)
                validationErrors.Add("IVA deve essere un valore positivo.");

            if (ScortaMinima <= 0)
                validationErrors.Add("ScortaMinima deve essere un valore positivo.");

            if (RicaricoMinimo < 0 || RicaricoMinimo > 100)
                validationErrors.Add("RicaricoMinimo deve essere una percentuale compresa tra 0 e 100.");

            if (SpeseSpedizioneListino <= 0)
                validationErrors.Add("SpeseSpedizioneListino deve essere un valore positivo.");

            if (MargineSSMinimo <= 0)
                validationErrors.Add("MargineSSMinimo deve essere un valore positivo.");

            if (DifferenzaMinima <= 0)
                validationErrors.Add("DifferenzaMinima deve essere un valore positivo.");

            if (SpeseSpedizioneRivenditore < SpeseSpedizioneListino)
                validationErrors.Add("SpeseSpedizioneRivenditore deve essere maggiore o uguale a SpeseSpedizioneListino.");

            return validationErrors.Count == 0;
        }
    }
}
