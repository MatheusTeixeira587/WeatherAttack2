using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.Spell.Request;

namespace WeatherAttack.Application.Command.Spell
{
    public class GetSpellCommand : CommandBase
    {
        public SpellRequestDto Result { get; set; }
    }
}
