using BCrypt;
using WeatherAttack.Contracts.interfaces;
using WeatherAttack.Security.Entities;

namespace WeatherAttack.Security.Services
{
    public sealed class PasswordService : IPasswordService
    {
        private SecuritySettings SecuritySettings { get; }

        public PasswordService(SecuritySettings securitySettings)
        {
            SecuritySettings = securitySettings;
        }

        public string HashPassword(string password)
            => BCryptHelper.HashPassword(password, BCryptHelper.GenerateSalt(SecuritySettings.SaltWorkFactor));

        public bool CheckPassword(string password, string hashed)
            => BCryptHelper.CheckPassword(password, hashed);
    }
}
