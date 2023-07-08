using System.ComponentModel.DataAnnotations;

namespace PriceMaster.ViewModels;

public class ConfigurationParameterViewModel
{
    public int Id { get; set; }

    [Display(Name = "IVA")]
    [Range(0, 100, ErrorMessage = "Il valore dell'IVA deve essere compreso tra 0 e 100.")]
    public decimal IVA { get; set; }

    [Display(Name = "Scorta Minima")]
    [Range(0, int.MaxValue, ErrorMessage = "La scorta minima deve essere un valore positivo.")]
    public int ScortaMinima { get; set; }

    [Display(Name = "Ricarico Minimo")]
    [Range(0, int.MaxValue, ErrorMessage = "Il ricarico minimo deve essere un valore positivo.")]
    public int RicaricoMinimo { get; set; }

    [Display(Name = "Spese Spedizione Listino")]
    [Range(0, double.MaxValue, ErrorMessage = "Le spese di spedizione del listino devono essere un valore positivo.")]
    public double SpeseSpedizioneListino { get; set; }

    [Display(Name = "Margine SS Minimo")]
    [Range(0, int.MaxValue, ErrorMessage = "Il margine SS minimo deve essere un valore positivo.")]
    public int MargineSSMinimo { get; set; }

    [Display(Name = "Differenza Minima")]
    [Range(0, double.MaxValue, ErrorMessage = "La differenza minima deve essere un valore positivo.")]
    public double DifferenzaMinima { get; set; }

    [Display(Name = "Spese Spedizione Rivenditore")]
    [Range(0, double.MaxValue, ErrorMessage = "Le spese di spedizione del rivenditore devono essere un valore positivo.")]
    public double SpeseSpedizioneRivenditore { get; set; }

    [Display(Name = "Valido dal")]
    [Required(ErrorMessage = "Il campo 'Valido dal' è obbligatorio.")]
    [DataType(DataType.Date)]
    public DateTime ValidFrom { get; set; }

    [Display(Name = "Valido fino al")]
    [DataType(DataType.Date)]
    public DateTime? ValidTo { get; set; }

    public bool IsEditing { get; set; }

    public Models.ConfigurationParameter ToConfigurationParameter()
    {
        return new Models.ConfigurationParameter
        {
            Id = Id,
            IVA = IVA,
            ScortaMinima = ScortaMinima,
            RicaricoMinimo = RicaricoMinimo,
            SpeseSpedizioneListino = (decimal)SpeseSpedizioneListino,
            MargineSSMinimo = MargineSSMinimo,
            DifferenzaMinima = (decimal)DifferenzaMinima,
            SpeseSpedizioneRivenditore = (decimal)SpeseSpedizioneRivenditore,
            ValidFrom = ValidFrom,
            ValidTo = ValidTo,
            IsCurrent = false,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = null
        };
    }

    public static ConfigurationParameterViewModel FromConfigurationParameter(Models.ConfigurationParameter parameter)
    {
        return new ConfigurationParameterViewModel
        {
            Id = parameter.Id,
            IVA = parameter.IVA,
            ScortaMinima = parameter.ScortaMinima,
            RicaricoMinimo = (int)parameter.RicaricoMinimo,
            SpeseSpedizioneListino = (double)parameter.SpeseSpedizioneListino,
            MargineSSMinimo = (int)parameter.MargineSSMinimo,
            DifferenzaMinima = (double)parameter.DifferenzaMinima,
            SpeseSpedizioneRivenditore = (double)parameter.SpeseSpedizioneRivenditore,
            ValidFrom = parameter.ValidFrom,
            ValidTo = parameter.ValidTo,
            IsEditing = false
        };
    }
}