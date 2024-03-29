﻿using PriceMaster.Models;

namespace PriceMaster.Repositories
{
    public interface IConfiguratonParameterRepository
    {
        IEnumerable<ConfigurationParameter> GetAll();
        ConfigurationParameter GetById(int id);
        ConfigurationParameter GetCurrentConfiguration();
        void Insert(ConfigurationParameter parameter);
        void Update(ConfigurationParameter parameter);
        void Delete(int id);
    }
}
