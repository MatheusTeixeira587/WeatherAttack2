using BCrypt;
using WeatherAttack.Contracts.interfaces;

namespace WeatherAttack.Security.Services
{
    public class PasswordService : IPasswordService
    {
        public string HashPassword(string password)
        {
            return BCryptHelper.HashPassword(password, BCryptHelper.GenerateSalt(16));
        }

        public bool CheckPassword(string password, string hashed)
        {
            return BCryptHelper.CheckPassword(password, hashed);
        }
        
    }
}
