namespace WeatherAttack.Application.Mapper
{
    public interface IMapper<E, D, R> where E : class where D : class where R : class
    {
        R ToDto(E e);

        E ToEntity(D d);
    }
}
