using System;
using System.Collections.Generic;
using WeatherAttack.Contracts.Dtos.User.Response;

namespace WeatherAttack.Application.Comparer.User
{
    public sealed class UserDtoComparer : IEqualityComparer<UserResponseDto>
    {
        public bool Equals(UserResponseDto x, UserResponseDto y)
            => x.Id == y.Id;

        public int GetHashCode(UserResponseDto obj)
            => HashCode.Combine(obj.Id);
    }
}
