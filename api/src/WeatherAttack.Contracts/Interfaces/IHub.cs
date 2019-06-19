using System;
using System.Collections.Generic;
using System.Text;
using WeatherAttack.Contracts.Dtos.User.Response;

namespace WeatherAttack.Contracts.Interfaces
{
    public interface IHub
    {
        long GetUserId();

        UserResponseDto GetUser();
    }
}