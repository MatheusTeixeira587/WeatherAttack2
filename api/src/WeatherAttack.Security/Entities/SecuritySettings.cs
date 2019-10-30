namespace WeatherAttack.Security.Entities
{
    public sealed class SecuritySettings
    {
        public string SigningKey { get; set; }

        public int TokenExpirationTime { get; set; }

        public int SaltWorkFactor { get; set; }
    }
}
