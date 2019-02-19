namespace WeatherAttack.Application.Mapper
{
    public interface IMapper<Entity, Request, Response> where Entity : class where Request : class where Response : class
    {
        Response ToDto(Entity entity);

        Entity ToEntity(Request request);
    }
}
