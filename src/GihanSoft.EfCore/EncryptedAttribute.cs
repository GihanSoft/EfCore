using System;

namespace GihanSoft.EfCore {
    [AttributeUsage (AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class EncryptedAttribute : Attribute {
        public bool UseSalt { get; set; } = true;
        public bool EncryptName { get; set; } = true;
    }
}