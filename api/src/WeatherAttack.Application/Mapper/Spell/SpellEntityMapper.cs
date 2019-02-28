using System.Linq;
using WeatherAttack.Contracts.Dtos.Spell.Request;
using WeatherAttack.Contracts.Dtos.SpellRule.Request;
using WeatherAttack.Contracts.Mapper;
using WeatherAttack.Domain.Enums;
using Entities = WeatherAttack.Domain.Entities;

namespace WeatherAttack.Application.Mapper.Spell
{
    public class SpellEntityMapper : IMapper<Entities.Spell, SpellRequestDto, SpellRequestDto>
    {
        private IMapper<Entities.SpellRule, SpellRuleRequestDto, SpellRuleRequestDto> SpellRuleMapper { get; }

        public SpellEntityMapper(IMapper<Entities.SpellRule, SpellRuleRequestDto, SpellRuleRequestDto> spellRuleMapper)
        {
            SpellRuleMapper = spellRuleMapper;
        }

        public SpellRequestDto ToDto(Entities.Spell entity)
        {
            return new SpellRequestDto()
            {
                Id = entity.Id,
                BaseDamage = entity.BaseDamage,
                BaseManaCost = entity.BaseManaCost,
                Element = (byte)entity.Element,
                Name = entity.Name,
                Rules = entity.Rules.Select(r => SpellRuleMapper.ToDto(r)).ToList()
            };
        }


        public Entities.Spell ToEntity(SpellRequestDto request)
        {
            return new Entities.Spell(
                request.Id,
                request.Name,
                request.BaseDamage,
                request.BaseManaCost,
                (Element)request.Element,
                request.Rules.Select(r => SpellRuleMapper.ToEntity(r)).ToList());
        }
    }
}
