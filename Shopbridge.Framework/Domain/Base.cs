namespace Shopbridge.Framework.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Base<T> : IEquatable<Base<T>>
    {
        public static bool operator !=(Base<T> a, Base<T> b) => !(a == b);

        public static bool operator ==(Base<T> a, Base<T> b)
        {
            if (a is null && b is null)
            {
                return true;
            }

            if (a is null || b is null)
            {
                return false;
            }

            return a.Equals(b);
        }

        public sealed override bool Equals(object obj) => Equals(obj as Base<T>);

        public bool Equals(Base<T> other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (GetType() != other.GetType())
            {
                return false;
            }

            return Equals().SequenceEqual(other.Equals());
        }

        public override int GetHashCode() => Equals().Aggregate(0, (a, b) => (a * 97) + b.GetHashCode());

        protected abstract IEnumerable<object> Equals();
    }
}