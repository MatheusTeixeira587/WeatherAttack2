using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.Spell.Response;

namespace WeatherAttack.Application.Command.Spell
{
    public class GetSpellCommand : CommandBase
    {
        public SpellResponseDto Result { get; set; }
    }
}
