using System;

namespace Gihan.EfCore
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public sealed class UnEncryptedAttribute : Attribute
    {
    }
}
