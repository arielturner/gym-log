namespace GymLog.UI.Utilities
{
    public static class StringExtensions
    {
        /// <summary>
        /// Strips the domain from a user name in the format "domain\username" or "username@domain".
        /// </summary>
        /// <param name="userName">The user name string.</param>
        /// <returns>The user name without the domain.</returns>
        public static string StripDomain(this string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                return userName;

            // Handle "domain\username"
            int backslashIndex = userName.IndexOf('\\');
            if (backslashIndex >= 0 && backslashIndex < userName.Length - 1)
                return userName[(backslashIndex + 1)..];

            // Handle "username@domain"
            int atIndex = userName.IndexOf('@');
            if (atIndex > 0)
                return userName[..atIndex];

            return userName;
        }
    }
}
