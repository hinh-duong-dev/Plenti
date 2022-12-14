using Moq;
using Plenti.Implements;
using Plenti.Model;

namespace PlentiTests
{

    [TestFixture]
    public class UserMatcherTest
    {
        private UserMatcher _userMatcher;

        [SetUp]
        public void SetUp()
        {
            _userMatcher = new UserMatcher();
        }

        [Test]
        public void IsWithin500Metres_ReturnTrue()
        {
            var newUser = new User
            {
                Name = "Mr A",
                ReferralCode = "BCD123",
                Address = new Address
                {
                    StreetAddress = "61 Pitt Street",
                    Suburb = "Sydney",
                    State = "NSW 2001",
                    Latitude = -33.863777m,
                    Longitude = 151.2088344m
                }
            };

            var existingUser = new User
            {
                Name = "Astrid Moody",
                ReferralCode = "ABC123",
                Address = new Address
                {
                    StreetAddress = "51 Pitt Street",
                    Suburb = "Sydney",
                    State = "NSW 2000",
                    Latitude = -33.8629779m,
                    Longitude = 151.2088393m
                }
            };

            var result = _userMatcher.IsMatch(newUser, existingUser);

            Assert.IsTrue(result, "The new user lives within 500 metres of an existing user their registration will be rejected");
        }
    }
}