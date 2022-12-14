using Plenti.Model;

namespace Plenti.Interfaces
{
    public interface IUserRegistrationService
    {
        bool IsMatchingWithExistingMembers(User newUser);
    }
}
