using Plenti.Model;

namespace Plenti.Interfaces
{
    public interface IUserMatcher
    {
        bool IsMatch(User newUser, User existingUser);
    }
}
