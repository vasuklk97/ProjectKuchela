using Microsoft.AspNetCore.Mvc;
using UserRegistration.Interface;
using UserRegistration.Models;

namespace UserRegistration.Service
{
    public class Registration : IRegistration
    {
        ISecurePasswordGenerationAndValidation _securePassword;
        IDBContext _dbContext;

        public Registration(ISecurePasswordGenerationAndValidation securePassword, IDBContext dbContext)
        {
            _securePassword = securePassword;
            _dbContext = dbContext;
        }

        public void UserRegistration(UserModel user)
        {
            //Creating Hashed password
            string salt = _securePassword.GenerateSalt();
            byte[] hashedPassword = _securePassword.GetHash(user.Password, salt);
            string hashedString = Convert.ToBase64String(hashedPassword);

            //Assigning hashed password to usermodel
            user.Salt = salt;
            user.HashedPassword = hashedString;

            //Save user details to database
            _dbContext.UserRegister(user);
        }
    }
}
