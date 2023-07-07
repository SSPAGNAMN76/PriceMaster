using PriceMaster.Models;

namespace PriceMaster.Repository
{
    public interface IConfiguratonParameterRepository
    {
        IEnumerable<ConfigurationParameter> GetAll();
        ConfigurationParameter GetById(int id);
        void Insert(ConfigurationParameter parameter);
        void Update(ConfigurationParameter parameter);
        void Delete(int id);
    }
}
