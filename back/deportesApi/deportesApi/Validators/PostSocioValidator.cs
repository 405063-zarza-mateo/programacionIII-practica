using deportesApi.Dtos;
using FluentValidation;

namespace deportesApi.Validators
{
    public class PostSocioValidator : AbstractValidator<SocioPostDto>
    {
        public PostSocioValidator() {
            RuleFor(x => x.Email).EmailAddress().WithMessage("Se debe ingresar in email valido.");
            RuleFor(x => x.Dni).Must(x => int.TryParse(x, out var dni)).WithMessage("El dni debe ser un numero.");
        }
    }
}
