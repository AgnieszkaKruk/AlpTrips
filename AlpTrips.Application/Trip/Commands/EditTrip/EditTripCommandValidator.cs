using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace AlpTrips.Application.Trip.Commands.EditTrip
{
    public class EditTripCommandValidator : AbstractValidator<EditTripCommand>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EditTripCommandValidator(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

            RuleFor(c => c.MountainRange)
                .NotEmpty().WithMessage("Nazwa pasma górskiego musi mieć co najmniej 3 litery")
                .MinimumLength(3).WithMessage("Nazwa pasma górskiego musi mieć co najmniej 3 litery")
                .When(c => IsSaving())
                
                .MaximumLength(25);

            RuleFor(c => c.Elevation)
                .NotEmpty().WithMessage("Przewyższenie musi być wartością dodatnią")
                .GreaterThan(0).WithMessage("Przewyższenie musi być wartością dodatnią")
                .When(c => IsSaving())
                .WithMessage("Przewyższenie musi być wartością dodatnią");

            RuleFor(c => c.Length)
                .NotEmpty().WithMessage("Długość trasy musi być wartością dodatnią")
                .GreaterThan(0).WithMessage("Długość trasy musi być wartością dodatnią")
                .When(c => IsSaving())
                .WithMessage("Długość trasy musi być wartością dodatnią");

            RuleFor(c => c.Time)
                .NotEmpty().WithMessage("Czas przejścia musi być wartością dodatnią")
                .GreaterThan(0).WithMessage("Czas przejścia musi być wartością dodatnią")
                .When(c => IsSaving())
                .WithMessage("Czas przejścia musi być wartością dodatnią");

            RuleFor(c => c.Level)
                .NotEmpty().WithMessage("Poziom trudności musi być między 1 i 5")
                .GreaterThan(0).WithMessage("Poziom trudności musi być między 1 i 5")
                .When(c => IsSaving())
                .WithMessage("Poziom trudności musi być między 1 i 5")
                .LessThanOrEqualTo(5)
                .WithMessage("Poziom trudności musi być między 1 i 5");
        }

        private bool IsSaving()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            return httpContext != null && httpContext.Request.Method == "POST";
        }
    }
}
