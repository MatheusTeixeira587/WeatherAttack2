﻿namespace WeatherAttack.Domain.Entities.Weather
{
    public sealed class Wind
    {
        public Wind(double speed)
        {
            Speed = speed;
        }

        public Wind()
        {
        }

        public double Speed { get; private set; }
    }
}
