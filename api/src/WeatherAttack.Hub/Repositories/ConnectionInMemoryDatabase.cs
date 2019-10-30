using System;
using System.Collections.Generic;
using System.Linq;
using WeatherAttack.Contracts.Dtos.User.Response;
using WeatherAttack.Contracts.Interfaces;

namespace WeatherAttack.Hub.Repositories
{
    public sealed class ConnectionInMemoryDatabase : IConnectionRepository<UserResponseDto>
    {
        private readonly Dictionary<UserResponseDto, string> _connections;

        public int Count => _connections.Count;

        public void Add(UserResponseDto key, string value)
            => _connections[key] = value;

        public void Remove(UserResponseDto key)
            => _connections.Remove(key);

        public string GetConnection(UserResponseDto key) 
            => _connections.GetValueOrDefault(key);

        public ICollection<UserResponseDto> Get() 
            => _connections.Keys;

        public UserResponseDto Find(UserResponseDto key)
            => _connections.Keys.SingleOrDefault(u => u.Id == key.Id);

        public UserResponseDto Find(string connection)
            => _connections.Where(r => r.Value == connection)?.Select(r => r.Key)?.FirstOrDefault();

        public ConnectionInMemoryDatabase(IEqualityComparer<UserResponseDto> comparer)
        {
            _connections = new Dictionary<UserResponseDto, string>(comparer);
        }
    }
}
