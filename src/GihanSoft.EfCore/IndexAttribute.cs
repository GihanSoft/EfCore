using System;

namespace Gihan.EfCore {
    [AttributeUsage (AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public sealed class IndexAttribute : Attribute {
        public bool IsUnique { get; set; } = false;
    }
}