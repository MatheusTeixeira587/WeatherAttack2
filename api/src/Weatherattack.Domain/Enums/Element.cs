using System;

namespace WeatherAttack.Domain.Enums
{
    [Flags]
    public enum Element : byte
    {
        None = 0,
        Fire = 1,
        Ice = 2,
        Lightning = 4,
        Water = 8,
        Wind = 16,
    }
}