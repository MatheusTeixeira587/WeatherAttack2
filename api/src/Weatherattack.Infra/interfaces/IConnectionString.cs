using System;
using System.Collections.Generic;
using System.Text;

namespace Weatherattack.Infra.interfaces
{
    public interface IDatabaseOptions 
    {
        string ConnectionString { get; }
    }
}
