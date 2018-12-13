using Weatherattack.Infra.Interfaces;

namespace Weatherattack.Infra.DatabaseOptions
{
    public class DataBaseOptions : IDatabaseOptions
    {
        public string ConnectionString { get ; private set ; }

        public DataBaseOptions(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
    }
}
