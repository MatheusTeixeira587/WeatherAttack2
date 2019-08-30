using System.Threading.Tasks;

namespace WeatherAttack.Contracts.interfaces
{
    public interface IPasswordService
    {
        string HashPassword(string password);

        bool CheckPassword(string password, string hashed);
    }
}
