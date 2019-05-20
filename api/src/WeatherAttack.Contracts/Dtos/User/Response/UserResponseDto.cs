
using System;
using WeatherAttack.Domain.Entities;

namespace WeatherAttack.Contracts.Dtos.User.Response
{
    public class UserResponseDto
    {
        public long Id { get; set; }

        public string Email { get;  set; }

        public string Username { get;  set; }

        public Character Character { get; set; }

        public UserResponseDto(string email, string username)
        {
            Email = email;
            Username = username;
        }

        public UserResponseDto(string email, string username, Character character)
        {
            Email = email;
            Username = username;
            Character = character;
        }

        public UserResponseDto() { }
    }
}
