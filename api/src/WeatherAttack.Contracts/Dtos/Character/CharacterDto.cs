using WeatherAttack.Contracts.Dtos.User.Response;

namespace WeatherAttack.Contracts.Dtos.Character
{
    public sealed class CharacterDto
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public long HealthPoints { get; set; } 

        public long ManaPoints { get; set; }

        public long Battles { get; set; }

        public long Wins { get; set; }

        public long Losses { get; set; }

        public long Medals { get; set; }
    }
}
