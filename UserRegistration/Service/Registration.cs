using Microsoft.AspNetCore.Mvc;
using UserRegistration.Interface;
using UserRegistration.Models;

namespace UserRegistration.Service
{
    public class Registration : IRegistration
    {
        ISecurePasswordGenerationAndValidation _securePassword;

        public Registration(ISecurePasswordGenerationAndValidation securePassword)
        {
            _securePassword = securePassword;
        }

        public void UserRegistration(UserModel user)
        {
            string salt = _securePassword.GenerateSalt();
            byte[] hashedPassword = _securePassword.GetHash(user.Password, salt);
            string hashedString = Convert.ToBase64String(hashedPassword);
            
            Console.WriteLine(user.FirstName);
        }
    }
}
