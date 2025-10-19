using System.Security.Cryptography;
using System.Text;

namespace FantasyTradesGroupService.Domain.ValueObjects
{
    public class GroupCode
    {
        public string Value { get; private set; }

        private GroupCode() { }

        private GroupCode(string value)
        {
            Value = value;
        }

        public static GroupCode Generate()
        {
            var bytes = new byte[4];
            RandomNumberGenerator.Fill(bytes);
            return new GroupCode(BitConverter.ToString(bytes).Replace("-", "").Substring(0, 6));
        }

        public static GroupCode FromString(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new ArgumentException("Group code cannot be empty.");

            return new GroupCode(code.ToUpperInvariant());
        }

        public override string ToString() => Value;
    }
}
