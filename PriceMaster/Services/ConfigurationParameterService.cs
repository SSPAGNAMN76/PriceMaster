using PriceMaster.Models;
using PriceMaster.Repositories;

namespace PriceMaster.Services
{
    public class ConfigurationParameterService : IConfigurationParameterService
    {
        private readonly IConfiguratonParameterRepository _repository;

        public ConfigurationParameterService(IConfiguratonParameterRepository repository)
        {
            _repository = repository;
        }


        public IEnumerable<ConfigurationParameter> GetAllParameters() => _repository.GetAll();

        public ConfigurationParameter GetParameterById(int id) => _repository.GetById(id);

        public ConfigurationParameter GetCurrentConfiguration() => _repository.GetCurrentConfiguration();
       

        public void AddParameter(ConfigurationParameter parameter)
        {
            parameter.ValidFrom = DateTime.UtcNow;
            parameter.ValidTo = null;
            parameter.IsCurrent = true;
            parameter.CreatedAt = DateTime.UtcNow;
            parameter.UpdatedAt = null;

            _repository.Insert(parameter);
        }

        public void UpdateParameter(ConfigurationParameter parameter)
        {
            var currentParameter = _repository.GetById(parameter.Id);
            currentParameter.ValidTo = DateTime.UtcNow;
            currentParameter.IsCurrent = false;
            currentParameter.UpdatedAt = DateTime.UtcNow;

            _repository.Update(currentParameter);

            parameter.Id = 0; 
            parameter.ValidFrom = DateTime.UtcNow;
            parameter.ValidTo = null;
            parameter.IsCurrent = true;
            parameter.CreatedAt = DateTime.UtcNow;
            parameter.UpdatedAt = null;

            _repository.Insert(parameter);
        }

        public void DeleteParameter(int id)
        {
            _repository.Delete(id);
        }
    }
}
