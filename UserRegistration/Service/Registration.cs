using Microsoft.AspNetCore.Mvc;
using UserRegistration.Interface;
using UserRegistration.Models;

namespace UserRegistration.Service
{
    public class Registration : IRegistration
    {
        public void UserRegistration(User user)
        {
            Console.WriteLine(user.FirstName);
        }
    }
}
