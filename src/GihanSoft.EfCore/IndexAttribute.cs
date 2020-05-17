using System;

namespace GihanSoft.EfCore {
    [AttributeUsage (AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public sealed class IndexAttribute : Attribute {
        public bool IsUnique { get; set; } = false;

        /// <summary>
        /// The index name
        /// </summary>
        public string Name { get; set; }
    }
}