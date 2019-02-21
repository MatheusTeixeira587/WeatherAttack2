using System;

namespace WeatherAttack.Domain.Enums
{
    public enum Operator : byte
    {
        HIGHER_THAN,
        LOWER_THAN, 
        EQUAL,
        HIGHER_OR_EQUAL_TO,
        LOWER_OR_EQUAL_TO
    }
}
