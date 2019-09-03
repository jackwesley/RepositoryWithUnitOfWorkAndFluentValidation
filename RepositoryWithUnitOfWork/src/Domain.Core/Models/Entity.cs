using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.Models
{
    //Classe do tipo abstrata não pode ser implementada, apenas herdada
    public abstract class Entity<T> : AbstractValidator<T> where T : Entity<T>
    {
        //Protect pois só a classe que herdar de entity poderão setar este Guid
        public Guid Id { get; protected set; }
        public abstract bool IsValid();
        public ValidationResult ValidationResult { get; protected set; }

        protected Entity()
        {
            ValidationResult = new ValidationResult(); 
        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity<T>;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(this, null)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity<T> a, Entity<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity<T> a, Entity<T> b)
        {

            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + "[Id = " + Id + "]";
        }

    }
}
