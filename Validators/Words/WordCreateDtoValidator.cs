using FluentValidation;
using Tabo.DTOs.Words;

namespace Tabo.Validators.WordCreateDtoValidators
{
    public class WordCreateDtoValidator:AbstractValidator<WordCreateDto>
    {
        public WordCreateDtoValidator() 
        {
            RuleFor(x => x.Text)
                .NotEmpty()
                    .WithMessage("Word cann't be empty")
                .NotNull()
                    .WithMessage("Word cann't be null")
                .MaximumLength(24)
                .MinimumLength(3);

        }
    }
}
