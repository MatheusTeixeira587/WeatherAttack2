using WeatherAttack.Application.Contracts.Command;
using WeatherAttack.Application.Contracts.Dtos.Spell.Request;

namespace WeatherAttack.Application.Command.Spell
{
    public class GetSpellCommand : CommandBase
    {
        public SpellRequestDto Result { get; set; }
    }
}
