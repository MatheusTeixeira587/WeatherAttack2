using WeatherAttack.Application.Contracts.Dtos.Spell.Request;
using WeatherAttack.Application.Contracts.Dtos.SpellRule.Request;
using WeatherAttack.Domain.Enums;
using Entities = WeatherAttack.Domain.Entities;

namespace WeatherAttack.Application.Mapper.SpellRule
{
    public class SpellRuleEntityMapper : IMapper<Entities.SpellRule, SpellRuleRequestDto, SpellRuleRequestDto>
    {
        public SpellRuleRequestDto ToDto(Entities.SpellRule entity)
        {
            return new SpellRuleRequestDto()
            {
                Id = entity.Id,
                Operator = (byte)entity.Operator,
                WeatherCondition = (byte)entity.WeatherCondition,
                Value = entity.Value,
            };
        }

        public Entities.SpellRule ToEntity(SpellRuleRequestDto request)
        {
            return new Entities.SpellRule(
                request.Id,
                new Entities.Spell(request.Id),
                request.Value,
                (Operator)request.Operator,
                (WeatherCondition)request.WeatherCondition
            );
        }
    }
}
