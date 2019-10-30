using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.Spell.Response;

namespace WeatherAttack.Application.Command.Spell
{
    public sealed class GetSpellCommand : CommandBase
    {
        public SpellResponseDto Result { get; set; }
    }
}
