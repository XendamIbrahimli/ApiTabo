using FluentValidation;
using Tabo.DTOs.BannedWords;

namespace Tabo.Validators.BannedWords
{
    public class BannedWordCreateValidator:AbstractValidator<BannedWordCreateDto>
    {
        public BannedWordCreateValidator() 
        { 
            RuleFor(x=>x.Text)
                .NotEmpty()
                .NotNull()
                .MaximumLength(24)
                .MinimumLength(3);
        }  
    }
}
