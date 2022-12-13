using Plenti.Entities;

namespace Plenti.Services
{
    public interface IUserRegistrationService
    {
        bool IsMatchingWithExistingMembers(User newUser);
    }
}
