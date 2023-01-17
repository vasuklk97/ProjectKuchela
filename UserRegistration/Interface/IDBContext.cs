using UserRegistration.Models;

namespace UserRegistration.Interface
{
    public interface IDBContext
    {
        public void UserRegister(UserModel user);
        public void GetHashAndSalt(ref LoginModel login);
    }
}
