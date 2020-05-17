using System;

namespace GihanSoft.EfCore {
    [AttributeUsage (AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public sealed class UnEncryptedAttribute : Attribute { }
}