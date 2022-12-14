using Plenti.Interfaces;
using Plenti.Model;
using static Plenti.Utils.AppUtils;

namespace Plenti.Implements
{
    public class UserMatcher : IUserMatcher
    {
        private const int MIN_DISTANCE = 500;

        public bool IsMatch(User newUser, User existingUser)
        {
            
            var distance = CalculateDistance(newUser.Address.Latitude, existingUser.Address.Latitude, newUser.Address.Longitude, existingUser.Address.Longitude);

            if (distance <= MIN_DISTANCE)
            {
                return true;
            }

            if (newUser.Name == existingUser.Name &&
                newUser.Address.StreetAddress.RemoveUnusualCharacters() == existingUser.Address.StreetAddress.RemoveUnusualCharacters() &&
                newUser.Address.Suburb.RemoveUnusualCharacters() == existingUser.Address.Suburb.RemoveUnusualCharacters() &&
                newUser.Address.State.RemoveUnusualCharacters() == existingUser.Address.State.RemoveUnusualCharacters())
            {
                return true;
            }

            if (newUser.ReferralCode.IsMatchReferralCode(existingUser.ReferralCode))
            {
                return true;
            }

            return false;
        }
    }
}
