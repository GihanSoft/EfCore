using GihanSoft;
using GihanSoft.Security.Cryptography;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Globalization;

namespace Gihan.EfCore
{
    public class ValueToStringConverter : ValueConverter<IConvertible, string>
    {
        protected static bool IsTypeValid(Type type)
        {
            return
                type == typeof(bool) ||
                type == typeof(char) ||
                type == typeof(DateTimeOffset) ||
                type == typeof(DateTime) ||
                type == typeof(TimeSpan) ||
                type == typeof(Guid) ||
                type == typeof(sbyte) ||
                type == typeof(byte) ||
                type == typeof(short) ||
                type == typeof(ushort) ||
                type == typeof(int) ||
                type == typeof(uint) ||
                type == typeof(long) ||
                type == typeof(ulong) ||
                type == typeof(float) ||
                type == typeof(double) ||
                type == typeof(decimal) ||
                type.IsEnum;
        }

        protected static string TtoStr(IConvertible value)
        {
            return value?.ToString(CultureInfo.InvariantCulture);
        }

        protected static IConvertible StrToT(string value, Type type)
        {
            if (!IsTypeValid(type))
                throw new ArgumentException($"Type {type} is not supported.", nameof(type));
            IConvertible val = value;
            return (IConvertible)val?.ToType(type, CultureInfo.InvariantCulture);
        }

        public ValueToStringConverter(Type type)
            : base(value => TtoStr(value), value => StrToT(value, type))
        {
            if (!IsTypeValid(type))
                throw new Exception($"Type {type} is not supported.");
        }
    }

    public class StringToEncryptedConverter : ValueConverter<string, string>
    {
        public StringToEncryptedConverter(ICrypto cryptographer, bool haveSalt)
            : base(v => v.Decode().Encrypt(cryptographer, haveSalt).EncodeBase64(),
                   v => v.DecodeBase64().Decrypt(cryptographer, haveSalt).Encode())
        {
        }
    }
}
