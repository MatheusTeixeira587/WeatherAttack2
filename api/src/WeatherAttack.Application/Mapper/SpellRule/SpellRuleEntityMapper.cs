using WeatherAttack.Application.Contracts.Dtos.Spell.Request;
using WeatherAttack.Application.Contracts.Dtos.SpellRule.Request;
using WeatherAttack.Domain.Enums;
using Entities = WeatherAttack.Domain.Entities;

namespace WeatherAttack.Application.Mapper.SpellRule
{
    public class SpellRuleEntityMapper : IMapper<Entities.SpellRule, SpellRuleRequestDto, SpellRuleRequestDto>
    {
        private readonly IMapper<Entities.Spell, SpellRequestDto, SpellRequestDto> SpellMapper;

        public SpellRuleEntityMapper(IMapper<Entities.Spell, SpellRequestDto, SpellRequestDto> spellMapper)
        {
            SpellMapper = spellMapper;
        }

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
                SpellMapper.ToEntity(request.Spell),
                request.Value,
                (Operator)request.Operator,
                (WeatherCondition)request.WeatherCondition
            );
        }
    }
}
