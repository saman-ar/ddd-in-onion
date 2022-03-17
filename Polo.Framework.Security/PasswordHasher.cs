using Polo.Framework.Core.Security;

namespace Polo.Framework.Security
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Hash(string plainText,string soltedValue)
        {
            return plainText;
        }
    }
}
