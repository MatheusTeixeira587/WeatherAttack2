using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherAttack.Application.Mapper
{
    public interface IEntityMapper<E, D, R> where E : class where D : class where R : class
    {
        R ToDto(E e);

        E ToEntity(D d);
    }
}
