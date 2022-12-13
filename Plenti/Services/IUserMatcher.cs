using Plenti.Entities;

namespace Plenti.Services
{
    public interface IUserMatcher
    {
        bool IsMatch(User newUser, User existingUser);
    }
}
