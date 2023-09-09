namespace ASP_Net_base.Modules.Accounts.Ports
{
    public interface IPasswordHasher
    {
        string CalculateHash(string password);
        bool IsPasswordEqualHashed(string hashedPassword, string inputPassword);
    }
}
