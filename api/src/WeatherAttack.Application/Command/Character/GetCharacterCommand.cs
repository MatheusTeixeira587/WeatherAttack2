using WeatherAttack.Contracts.Command;
using Entities = WeatherAttack.Domain.Entities;

namespace WeatherAttack.Application.Command.Character
{
    public class GetCharacterCommand : CommandBase
    {
        public Entities.Character Result { get; set; }
    }
}
