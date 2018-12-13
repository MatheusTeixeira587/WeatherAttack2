using System;
using System.Collections.Generic;
using System.Text;
using Weatherattack.Infra.interfaces;

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
