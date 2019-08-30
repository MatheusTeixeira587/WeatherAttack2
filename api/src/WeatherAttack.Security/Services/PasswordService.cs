using BCrypt;
using WeatherAttack.Contracts.interfaces;

namespace WeatherAttack.Security.Services
{
    public class PasswordService : IPasswordService
    {
        public PasswordService(byte workFactor) => SaltWorkFactor = workFactor;

        private byte SaltWorkFactor;

        public string HashPassword(string password)
            => BCryptHelper.HashPassword(password, BCryptHelper.GenerateSalt(SaltWorkFactor));

        public bool CheckPassword(string password, string hashed)
            => BCryptHelper.CheckPassword(password, hashed);
    }
}
