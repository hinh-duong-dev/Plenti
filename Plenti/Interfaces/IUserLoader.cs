using Plenti.Model;

namespace Plenti.Interfaces
{
    public interface IUserLoader
    {
        IEnumerable<User> GetAllUser();
    }
}
