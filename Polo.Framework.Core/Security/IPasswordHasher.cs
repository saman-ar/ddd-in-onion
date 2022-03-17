using System;

namespace Polo.Framework.Core.Security
{
    public interface IPasswordHasher
    {
        string Hash(string plainText ,string soltedValue);
    }
}
