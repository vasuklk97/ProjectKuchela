using Microsoft.AspNetCore.Mvc;
using UserRegistration.Models;

namespace UserRegistration.Interface
{
    public interface IRegistration
    {
        public void UserRegistration(User user);
    }
}
