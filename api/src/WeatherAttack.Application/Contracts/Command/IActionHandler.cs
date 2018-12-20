namespace WeatherAttack.Application.Contracts.Command
{
    public interface IActionHandler<T> where T : ICommand
    {
        void HandleAction(T entity);
    }
}
