using PriceMaster.Models;

namespace PriceMaster.Views.Administrator
{
    public class ConfigurationParametersViewModel
    {
        public ConfigurationParameter ConfigurationParameter { get; set; }
        public bool ContentSaved { get; set; }
        public List<string> ValidationErrors { get; set; }
    }
}
