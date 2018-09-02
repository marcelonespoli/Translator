using FluentValidation;
using FluentValidation.Results;
using System;

namespace MNS.Translator.Domain.Models
{
    public abstract class Entity<T> : AbstractValidator<T> where T : Entity<T>  
    {
        public Guid Id { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
            ValidationResult = new ValidationResult();
        }

        public abstract bool IsValid();
    }
}
