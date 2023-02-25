namespace TransfloTask.Shared.Handlers
{
    public static class StringHandler
    {
        public static string GetRandomString()
        {
            var chars = "abcdefghijklmnopqrstuvwxyz";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 8)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}