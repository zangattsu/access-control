using FluentValidation.Results;
using System.Diagnostics.CodeAnalysis;

namespace AccessControl.Domain
{
    public abstract class Entity<T>
    {
        protected Entity()
        {
            ValidationResult = new ValidationResult();
        }

        public int Id { get; protected set; }

        public ValidationResult ValidationResult { get; protected set; }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            var compareTo = obj as Entity<T>;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo!.Id); // CS8602: Dereference of a possibly null reference.
        }

        public static bool operator ==(Entity<T>? a, Entity<T>? b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b); // CS8602: Dereference of a possibly null reference.
        }

        public static bool operator !=(Entity<T>? a, Entity<T>? b)
        {
            return !(a == b); // CS8603: Possible null reference return.
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode() * 907 + Id.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + "[Id = " + Id + "]";
        }
    }
}