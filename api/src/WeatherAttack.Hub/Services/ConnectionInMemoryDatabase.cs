using System;
using System.Collections.Generic;
using System.Text;
using WeatherAttack.Contracts.Dtos.User.Response;

namespace WeatherAttack.Hub.Services
{
    public class ConnectionInMemoryDatabase
    {
        private readonly Dictionary<UserResponseDto, string> _connections;

        public ConnectionInMemoryDatabase()
            => _connections = new Dictionary<UserResponseDto, string>(new UserComparer());

        public int Count 
            => _connections.Count;

        public void Add(UserResponseDto key, string value) 
            =>  _connections.Add(key, value);

        public void Remove(UserResponseDto key) 
            => _connections.Remove(key);

        public string Get(UserResponseDto key) 
            => _connections.GetValueOrDefault(key);

        public ICollection<UserResponseDto> Get() 
            => _connections.Keys;

        private class UserComparer : IEqualityComparer<UserResponseDto>
        {
            public bool Equals(UserResponseDto x, UserResponseDto y) 
                => x.Id == y.Id;
            
            public int GetHashCode(UserResponseDto obj) 
                => HashCode.Combine(obj.Id);
        }
    }
}
