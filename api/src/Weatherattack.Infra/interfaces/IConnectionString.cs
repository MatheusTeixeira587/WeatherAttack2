using System;
using System.Collections.Generic;
using System.Text;

namespace Weatherattack.Infra.Interfaces
{
    public interface IDatabaseOptions 
    {
        string ConnectionString { get; }
    }
}
