using Microsoft.AspNetCore.Mvc;
using Plenti.Interfaces;
using Plenti.Model;

namespace Plenti.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : ControllerBase
    {
        
        private readonly ILogger<RegistrationController> _logger;
        private readonly IUserRegistrationService _userRegistrationService;

        public RegistrationController(ILogger<RegistrationController> logger, IUserRegistrationService userRegistrationService)
        {
            _logger = logger;
            _userRegistrationService = userRegistrationService;
        }

        [HttpPost("IsMatchingWithExistingMembers")]
        public IActionResult IsMatchingWithExistingMembers([FromBody] User newUser)
        {
            if (ModelState.IsValid)
            {
                var res = _userRegistrationService.IsMatchingWithExistingMembers(newUser);

                return Ok(res);
            }

            return BadRequest(ModelState);
        }
    }
}