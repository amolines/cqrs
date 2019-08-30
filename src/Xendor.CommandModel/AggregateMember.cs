using System;

namespace Xendor.CommandModel
{
    public class AggregateMember : IAggregateMember
    {
        protected AggregateMember()
        {
            Id = IdentityGenerator.NewSequentialGuid(IdentityGeneratorType.SequentialAsString);
        }
        protected AggregateMember(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; protected set; }
        public override bool Equals(object obj)
        {
            if (!(obj is AggregateMember))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (GetType() != obj.GetType())
                return false;

            var other = (AggregateMember)obj;
            var typeOfThis = GetType();
            var typeOfOther = other.GetType();
            if (!typeOfThis.IsAssignableFrom(typeOfOther) && !typeOfOther.IsAssignableFrom(typeOfThis))
            {
                return false;
            }

            return Id.Equals(other.Id);
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ 31;
        }
        public static bool operator ==(AggregateMember left, AggregateMember right)
        {
            return left?.Equals(right) ?? Equals(right, null);
        }
        public static bool operator !=(AggregateMember left, AggregateMember right)
        {
            return !(left == right);
        }
        public override string ToString()
        {
            return $"[{GetType().Name} {Id}]";
        }
    }
}