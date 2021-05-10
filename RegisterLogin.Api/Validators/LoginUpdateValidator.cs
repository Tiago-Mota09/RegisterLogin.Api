using FluentValidation;
using RegisterLogin.Api.Domain.Models.Request;

namespace RegisterLogin.Api.Validators
{
    public class LoginUpdateValidator : AbstractValidator<LoginUpdateRequest>
    {
        public LoginUpdateValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.IdLogin)
               .NotNull().WithMessage("Informe o Id")//Não pode ser nulo
               .NotEmpty().WithMessage("informe o Id")//não pode vazio
               .GreaterThan(0).WithMessage("Informe o nome"); //Não pode zero
       }
    }
}
