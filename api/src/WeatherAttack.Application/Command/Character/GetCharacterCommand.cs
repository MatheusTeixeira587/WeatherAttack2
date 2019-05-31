using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.Character;

namespace WeatherAttack.Application.Command.Character
{
    public class GetCharacterCommand : CommandBase
    {
        public CharacterDto Result { get; set; }
    }
}
