namespace UserRegistration.Interface
{
    public interface ISecurePasswordGenerationAndValidation
    {
        public string GenerateSalt();
        public byte[] GetHash(string password, string salt);
        public bool PasswordValidation(string password, string hash, string salt);
    }
}
