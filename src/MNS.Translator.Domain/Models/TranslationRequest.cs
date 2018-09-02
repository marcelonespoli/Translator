using FluentValidation;
using System;

namespace MNS.Translator.Domain.Models
{
    public class TranslationRequest : Entity<TranslationRequest>
    {
        public string Text { get; set; }
        public string Translation { get; set; }
        public string ErrorMessage { get; set; }
        public bool Success { get; set; }        
        public DateTime Date { get; set; }
        public string Ip { get; set; }


        public override bool IsValid()
        {
            Validate();
            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }

        #region Validations

        private void Validate()
        {
            RuleFor(c => c.Text)
                .NotEmpty().WithMessage("The text must be supplied.");

            RuleFor(c => c.Translation)
                .NotEmpty().When(c => c.Success == true)
                .WithMessage("The translation must be supplied.");

            RuleFor(c => c.ErrorMessage)
                .NotEmpty().When(c => c.Success == false)
                .WithMessage("The message error must be supplied.");            
        }

        #endregion
    }
}
