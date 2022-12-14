using Plenti.Interfaces;
using Plenti.Model;

namespace Plenti.Implements
{
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly IUserMatcher _userMatcher;
        private readonly ILogger<UserRegistrationService> _logger; 
        private readonly IUserLoader _userLoader;

        public UserRegistrationService(ILogger<UserRegistrationService> logger, IUserMatcher userMatcher, IUserLoader userLoader)
        {
            _logger = logger;
            _userMatcher = userMatcher;
            _userLoader = userLoader;
        }

        public bool IsMatchingWithExistingMembers(User newUser)
        {
            var existingUsers = _userLoader.GetAllUser().ToList();

            foreach (var existingUser in existingUsers)
            {
                if (_userMatcher.IsMatch(newUser, existingUser))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
