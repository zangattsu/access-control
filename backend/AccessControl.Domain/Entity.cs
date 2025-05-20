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

            return Id.Equals(compareTo!.Id);
        }
    }
}