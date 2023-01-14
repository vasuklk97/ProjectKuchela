using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserRegistration.Interface;
using UserRegistration.Models;

namespace UserRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        IRegistration _registration;
        
        public RegistrationController(IRegistration registration)
        {
            _registration = registration;
        }
        [HttpPost]
        public IActionResult UserRegistration(User user)
        {
            _registration.UserRegistration(user);
            return Ok(user.FirstName);
        }
    }
}
