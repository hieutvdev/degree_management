using degree_management.constracts.Responses.Result;

namespace degree_management.constracts.Exceptions.Validations;

public class ValidationResult : Result, IValidationResult
{
    private ValidationResult(Error[] errors) : base(false, IValidationResult.ValidationError) => Errors = errors;
    public Error[] Errors { get; }

    public static ValidationResult WithErrors(Error[] errors) => new(errors);
}