using System;
using System.Collections.Generic;
using System.Linq;
using WeatherAttack.Contracts.Dtos.User.Response;
using WeatherAttack.Contracts.Interfaces;

namespace WeatherAttack.Hub.Repositories
{
    public class ConnectionInMemoryDatabase : IConnectionRepository<UserResponseDto>
    {
        private readonly Dictionary<UserResponseDto, string> _connections;

        public void Add(UserResponseDto key, string value)
        {
            if (_connections.ContainsKey(key))
                _connections.Remove(key);

              _connections.Add(key, value);
        }

        public void Remove(UserResponseDto key)
        {
            if (_connections.ContainsKey(key))
                _connections.Remove(key);
        }

        public string GetConnection(UserResponseDto key) 
            => _connections.GetValueOrDefault(key);

        public ICollection<UserResponseDto> Get() 
            => _connections.Keys;

        public UserResponseDto Find(UserResponseDto key)
            => _connections.Keys.SingleOrDefault(u => u.Id == key.Id);

        public ICollection<UserResponseDto> Find(ICollection<UserResponseDto> key)
            => _connections.Keys.Where(u => key.Select(k => k.Id).Contains(u.Id)).ToList();

        int IConnectionRepository<UserResponseDto>.Count()
            => _connections.Count;

        public ConnectionInMemoryDatabase(IEqualityComparer<UserResponseDto> comparer)
        {
            _connections = new Dictionary<UserResponseDto, string>(comparer);
        }
    }
}
