using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.Character;

namespace WeatherAttack.Application.Command.Character
{
    public sealed class GetCharacterCommand : CommandBase
    {
        public CharacterDto Result { get; set; }
    }
}
