namespace UrlShortener.WebApplication.Service.Impl
{
    public class RandomShortAliasGenerator : IShortAliasGenerator
    {
        public string GenerateShortAlias()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();

            var shortAlias = new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            return shortAlias;
        }
    }
}
