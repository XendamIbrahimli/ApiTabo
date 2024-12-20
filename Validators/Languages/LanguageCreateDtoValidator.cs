using FluentValidation;
using Tabo.DTOs.Languages;

namespace Tabo.Validators.Languages
{
    public class LanguageCreateDtoValidator : AbstractValidator<LanguageCreateDto>
    {
        public LanguageCreateDtoValidator()
        {
            RuleFor(x=>x.Code)
                .NotEmpty()
                    .WithMessage("Code don't be Empty")
                .NotNull()
                    .WithMessage("Code don't be Null")
                .Length(3)
                    .WithMessage("Code don't be long or small from 3");
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(32)
                .MinimumLength(3);
            RuleFor(x => x.Icon)
                .NotEmpty()
                .NotNull()
                .MaximumLength(128)
                .Matches("http(s)?://([\\w-]+\\.)+[\\w-]+(/[\\w- ./?%&=]*)?")
                    .WithMessage("Url must be link only");
                
                
        }
    }
}
