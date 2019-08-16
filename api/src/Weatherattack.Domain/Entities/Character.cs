using WeatherAttack.Domain.EntityValidation.Rules;

namespace WeatherAttack.Domain.Entities
{
    public class Character : EntityBase
    {
        public Character() { }

        public Character(long id, long userId, long healthPoints, long manaPoints, long battles, long wins, long losses, long medals) : base(id)
        {
            Id = id;
            UserId = userId;
            HealthPoints = healthPoints;
            ManaPoints = manaPoints;
            Battles = battles;
            Wins = wins;
            Losses = losses;
            Medals = medals;
        }

        public long UserId { get; set; }

        public long HealthPoints { get; private set; } = Rules.Character.HealthPoints.InitialValue;

        public long ManaPoints { get; private set; } = Rules.Character.ManaPoints.InitialValue;

        public long Battles { get; private set; } = Rules.Character.Battles.InitialValue;

        public long Wins { get; private set; } = Rules.Character.Wins.InitialValue;

        public long Losses { get; private set; } = Rules.Character.Losses.InitialValue;

        public long Medals { get; private set; } = Rules.Character.Medals.InitialValue;
    }
}
