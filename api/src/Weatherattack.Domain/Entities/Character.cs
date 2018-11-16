using System;
using System.Collections.Generic;
using System.Text;
using Weatherattack.Domain.EntityValidator.Rules.Character;
using weatherattack2.src.Domain.Entities;

namespace Weatherattack.Domain.Entities
{
    public class Character : EntityBase
    {

        public long HealthPoints { get; private set; } = CharacterRules.HealthPoints.InitialValue;

        public long ManaPoints { get; private set; } = CharacterRules.ManaPoints.InitialValue;

        public long Battles { get; private set; } = CharacterRules.Battles.InitialValue;

        public long Wins { get; private set; } = CharacterRules.Wins.InitialValue;

        public long Losses { get; private set; } = CharacterRules.Losses.InitialValue;

        public long Medals { get; private set; } = CharacterRules.Medals.InitialValue;

    }
}
