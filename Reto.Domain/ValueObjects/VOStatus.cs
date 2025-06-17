using System.Collections.Immutable;

namespace Reto.Domain.ValueObjects
{
    public sealed record VOStatus(int Value, string Name)
    {
        public static readonly VOStatus Inactive = new(0, "Inactive");
        public static readonly VOStatus Active = new(1, "Active");

        private static readonly ImmutableDictionary<int, VOStatus> _byValue =
            ImmutableDictionary.CreateRange(new[]
            {
            KeyValuePair.Create(Inactive.Value, Inactive),
            KeyValuePair.Create(Active.Value,   Active)
            });

        private static readonly ImmutableDictionary<string, VOStatus> _byName =
            _byValue.Values.ToImmutableDictionary(s => s.Name);

        public static IReadOnlyCollection<VOStatus> All => _byValue.Values.ToArray();

        public static VOStatus FromInt(int value) =>
            _byValue.TryGetValue(value, out var s)
                ? s
                : throw new ArgumentOutOfRangeException(nameof(value));

        public static VOStatus FromName(string name) =>
            _byName.TryGetValue(name, out var s)
                ? s
                : throw new ArgumentException(nameof(name));

        public override string ToString() => Name;
    }
}
