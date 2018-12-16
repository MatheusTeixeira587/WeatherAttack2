using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherAttack.Application.Contracts.interfaces
{
    public interface IPasswordService
    {
        string HashPassword(string password);

        bool CheckPassword(string password, string hashed);
    }
}
