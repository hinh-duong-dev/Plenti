using Plenti.Data;
using Plenti.Entities;


namespace Plenti.Services
{
    public class UserMatcher : IUserMatcher
    {
        private const int DISTANCE = 500;
        public UserMatcher(PlentiDbContext dbContext)
        {
        }

        public bool IsMatch(User newUser, User existingUser)
        {
            if (newUser.ReferralCode == existingUser.ReferralCode)
            {
                return true;
            }

            if (newUser.Address.FullAddress == existingUser.Address.FullAddress)
            {
                return true;
            }

            var distance = CalculateDistance(newUser.Address.Latitude, newUser.Address.Longitude, existingUser.Address.Latitude, existingUser.Address.Longitude);

            if (distance <= DISTANCE)
            {
                return true;
            }

            return false;
        }

        private decimal CalculateDistance(decimal x1, decimal x2, decimal y1, decimal y2)
        {
            var temp1 = Math.Pow((double)(x2 - x1), 2);
            var temp2 = Math.Pow((double)(y2 - y1), 2);

            return Convert.ToDecimal(Math.Sqrt(temp1 + temp2));

        }
    }
}
