namespace WeatherAttack.Contracts.Command
{
    public abstract class PagedCommand : CommandBase
    {
        public long PageSize = 20;

        public long PageNumber;

        public long PageCount;

        public long TotalRecords;
    }
}
