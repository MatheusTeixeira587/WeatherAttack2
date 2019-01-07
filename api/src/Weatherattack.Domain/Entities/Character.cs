using System.ComponentModel.DataAnnotations.Schema;
using WeatherAttack.Domain.EntityValidation.Rules.Character;

namespace WeatherAttack.Domain.Entities
{
    public class Character : EntityBase
    {
        public long UserId { get; set; }

        public long HealthPoints { get; private set; } = CharacterRules.HealthPoints.InitialValue;

        public long ManaPoints { get; private set; } = CharacterRules.ManaPoints.InitialValue;

        public long Battles { get; private set; } = CharacterRules.Battles.InitialValue;

        public long Wins { get; private set; } = CharacterRules.Wins.InitialValue;

        public long Losses { get; private set; } = CharacterRules.Losses.InitialValue;

        public long Medals { get; private set; } = CharacterRules.Medals.InitialValue;
    }
}
