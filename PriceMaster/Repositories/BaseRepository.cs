namespace PriceMaster.Repositories
{
    public abstract class BaseRepository
    {
        public readonly IConfiguration _configuration;
        public readonly string _connectionString;

        protected BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("PriceMasterConnectionString") ?? string.Empty;
        }
    }
}
