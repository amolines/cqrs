using System.Collections.Generic;
using System.Linq;

namespace Xendor.CommandModel
{
    /// <summary>
    /// An object that represents a descriptive aspect of the domain with no conceptual identity is called a Value Object. Value Objects are instantiated to represent elements of the design that we care about only for what they are, not who or which they are.
    /// In other words, value objects don’t have their own identity.
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// No identity: A corollary of value objects’ identity-less nature is, obviously, not having an AggregateId property. 
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Immutability:As any value object can be replaced by another value object with the same property set, it’s a good idea to make them immutable to simplify working with them, especially in multithread scenarios. 
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Lifetime shortening: It’s another corollary of the value objects’ identity-less nature. They can’t exist without a parent entity owning them. In other words, there always must be a composition relationship between a Value Object class and an AggregateMember class. Without it, value objects don’t make any sense.
    /// </description>
    /// </item>
    /// </list>
    /// <remarks>
    /// Domain Model Validation: A value object will validate the parameters in the constructor and should then be immutable. 
    /// </remarks>
    /// </summary>
    public abstract class ValueObject
    {
        private static bool EqualOperator(ValueObject left, ValueObject right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            {
                return false;
            }
            return ReferenceEquals(left, null) || left.Equals(right);
        }

        protected static bool NotEqualOperator(ValueObject left, ValueObject right)
        {
            return !(EqualOperator(left, right));
        }

        protected abstract IEnumerable<object> GetAtomicValues();

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }
            var other = (ValueObject)obj;
            var thisValues = GetAtomicValues().GetEnumerator();
            var otherValues = other.GetAtomicValues().GetEnumerator();
            while (thisValues.MoveNext() && otherValues.MoveNext())
            {
                if (ReferenceEquals(thisValues.Current, null) ^ ReferenceEquals(otherValues.Current, null))
                {
                    return false;
                }
                if (thisValues.Current != null && !thisValues.Current.Equals(otherValues.Current))
                {
                    return false;
                }
            }
            return !thisValues.MoveNext() && !otherValues.MoveNext();
        }

        public override int GetHashCode()
        {
            return GetAtomicValues()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }

        public ValueObject GetCopy()
        {
            return this.MemberwiseClone() as ValueObject;
        }
    }
}