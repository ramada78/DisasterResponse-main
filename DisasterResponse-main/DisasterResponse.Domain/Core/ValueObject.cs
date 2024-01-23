namespace DisasterResponse.Domain.Core;

public abstract class ValueObject : IEquatable<ValueObject>
{
    protected abstract IEnumerable<object> GetAtomicValues();
    private bool ValuesAreEqual(ValueObject other) => GetAtomicValues().SequenceEqual(other.GetAtomicValues());
    public override int GetHashCode() => GetAtomicValues().Aggregate(default(int), HashCode.Combine);
    public bool Equals(ValueObject? other) => other is not null && ValuesAreEqual(other);
    public override bool Equals(object? obj) => obj is ValueObject other && ValuesAreEqual(other);
    public static bool operator ==(ValueObject first, ValueObject second) => first.ValuesAreEqual(second);
    public static bool operator !=(ValueObject first, ValueObject second) => !(first == second);
}