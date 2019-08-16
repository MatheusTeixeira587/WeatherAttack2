﻿using System.Collections.Generic;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.Spell.Request;

namespace WeatherAttack.Application.Command.Spell
{
    public class GetAllSpellsCommand : CommandBase
    {
        public GetAllSpellsCommand(long id) : base(id) { }

        public ICollection<SpellRequestDto> Result;
    }
}
