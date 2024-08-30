namespace GeekyMon2.Azure.Function.RandomPasswordGenerator
{
    public class PasswordGenerator
    {
        internal string GeneratePassword(string? length)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, int.Parse(length))
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}