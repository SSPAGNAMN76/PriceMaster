using PriceMaster.Models;

namespace PriceMaster.Services
{
    public interface IConfigurationParameterService
    {
        IEnumerable<ConfigurationParameter> GetAllParameters();
        ConfigurationParameter GetParameterById(int id);
        ConfigurationParameter GetCurrentConfiguration();
        void AddParameter(ConfigurationParameter parameter);
        void UpdateParameter(ConfigurationParameter parameter);
        void DeleteParameter(int id);
    }
}
