using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using UserRegistration.Interface;
using UserRegistration.Models;

namespace UserRegistration.Controllers
{
    [Route("api")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        IRegistration _registration;
        ISecurePasswordGenerationAndValidation _securePassword;
        
        public RegistrationController(IRegistration registration, ISecurePasswordGenerationAndValidation securePassword)
        {
            _registration = registration;
            _securePassword = securePassword;
        }

        [HttpPost]
        [Route("UserRegistration")]
        public IActionResult UserRegistration(UserModel user)
        {
            try
            {
                
                _registration.UserRegistration(user);
                return Ok(user.FirstName);
                
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginModel loginModel)
        {
            try
            {
                string salt = "pfMfP8krTn6F1zWykI4FiA==";
                string hash = "SVS7FkJEBTbH6JjLaXuqYsDW2TLunhm2mrI4TdP9IRk=";
                bool loginSuccess = _securePassword.PasswordValidation(loginModel.Password, hash, salt);
                if (loginSuccess)
                    return Ok("Login Successful");
                else
                    return Unauthorized();

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
