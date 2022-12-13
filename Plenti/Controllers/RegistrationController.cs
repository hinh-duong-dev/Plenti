using Microsoft.AspNetCore.Mvc;
using Plenti.Data;
using Plenti.Entities;
using Plenti.Services;

namespace Plenti.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : ControllerBase
    {
        
        private readonly ILogger<RegistrationController> _logger;
        private readonly IUserMatcher _userMatcher;
        private readonly PlentiDbContext _dbContext;

        public RegistrationController(ILogger<RegistrationController> logger, PlentiDbContext dbContext, IUserMatcher userMatcher)
        {
            _logger = logger;
            _userMatcher = userMatcher;
            _dbContext = dbContext;
        }

       
        [HttpPost(Name = "Registration")]
        public bool IsMatchingWithExistingMembers(User newUser)
        {
            var a = _userMatcher.IsMatch(new User(), new User());

            return true;
        }
    }
}