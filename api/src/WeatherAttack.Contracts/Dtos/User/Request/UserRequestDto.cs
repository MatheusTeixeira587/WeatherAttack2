namespace WeatherAttack.Contracts.Dtos.User.Request
{
    public class UserRequestDto
    {
        public long Id { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public UserRequestDto(string email, string username, string password)
        {
            Email = email;
            Username = username;
            Password = password;
        }
    }
}
