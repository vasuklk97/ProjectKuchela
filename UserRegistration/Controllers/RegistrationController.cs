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
        IDBContext _dbContext;
        ISecurePasswordGenerationAndValidation _securePassword;
        
        public RegistrationController(IRegistration registration, 
            ISecurePasswordGenerationAndValidation securePassword,
            IDBContext dBContext
            )
        {
            _registration = registration;
            _securePassword = securePassword;
            _dbContext = dBContext;
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
                //Get Hash and Salt values from DB for specific User
                _dbContext.GetHashAndSalt(ref loginModel);

                //Validate password by hashing and comparing with DB 
                bool loginSuccess = _securePassword.PasswordValidation(loginModel.Password, loginModel.HashedPassword, loginModel.Salt);
                
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
