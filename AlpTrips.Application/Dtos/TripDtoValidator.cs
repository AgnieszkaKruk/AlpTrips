using AlpTrips.Domain.Interfaces;
using FluentValidation;

namespace AlpTrips.Application.Dtos
{
    public class TripDtoValidator : AbstractValidator<TripDto>
    {

        public TripDtoValidator(ITripRepository tripRepository)
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .MinimumLength(3)
                .WithMessage("Nazwa wycieczki musi mieć co najmniej 3 litery")
                .MaximumLength(25)
                .Custom((value, context) =>
                {
                    var existingTrip = tripRepository.GetByName(value).Result;
                    if (existingTrip != null)
                    {
                        context.AddFailure($"Nazwa {value} już istnieje");
                    }
                }

                );

            RuleFor(c => c.MountainRange)
                .NotEmpty()
                .MinimumLength(3)
                .WithMessage("Nazwa pasma górskiego musi mieć co najmniej 3 litery")
                .MaximumLength(25);

            RuleFor(c => c.Elevation)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Przewyższenie musi być wartoscią dodatnią");

            RuleFor(c => c.Length)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Długość trasy musi być wartoscią dodatnią");

            RuleFor(c => c.Time)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Czas przejścia musi być wartoscią dodatnią");

            RuleFor(c => c.Level)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Poziom trudności musi być między 1 i 5")
                .LessThanOrEqualTo(5)
                .WithMessage("Poziom trudności musi być między 1 i 5");

            RuleFor(c => c.Email)
               .NotEmpty()
               .WithMessage("Adres email użytkownika jest wymagany")
               .EmailAddress()
               .WithMessage("Nieprawidłowy adres e-mail");

            //RuleFor(c=>c.ImageUrl)
            //    .Must(x => Uri.TryCreate(x, UriKind.Absolute, out Uri uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
            //.WithMessage("Wprowadź poprawny adres URL.");



        }
    }
}
