namespace WeatherAttack.Contracts.Command
{
    public interface IActionHandler<T> where T : CommandBase
    {
        T ExecuteAction(T command);
    }
}
