using degree_management.application.UseCases.V1.Commands.Faculty.Create;
using FluentValidation;

namespace degree_management.application.UseCases.V1.Validations.Faculty;

public class CreateFacultyCommandValidation : AbstractValidator<CreateFacultyCommand>
{
    public CreateFacultyCommandValidation()
    {
        RuleFor(r => r.Request.Name)
            .NotEmpty()
            .WithMessage("Name is required");
        RuleFor(r => r.Request.Code)
            .NotEmpty()
            .WithMessage("Code is required");
        
    }
}

