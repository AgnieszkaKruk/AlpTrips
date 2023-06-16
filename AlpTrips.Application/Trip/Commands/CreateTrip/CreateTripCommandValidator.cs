using AlpTrips.Application.Dtos;
using AlpTrips.Domain.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace AlpTrips.Application.Trip.Commands.CreateTrip
{
    public class CreateTripCommandValidator : AbstractValidator<CreateTripCommand>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateTripCommandValidator(ITripRepository tripRepository, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Nazwa wycieczki musi mieć co najmniej 3 litery")
                .MinimumLength(3).WithMessage("Nazwa wycieczki musi mieć co najmniej 3 litery")
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

            //RuleFor(c => c.MountainRange)
            //    .NotEmpty().WithMessage("Nazwa pasma górskiego musi mieć co najmniej 3 litery")
            //    .MinimumLength(3).WithMessage("Nazwa pasma górskiego musi mieć co najmniej 3 litery")
            //    .WithMessage("Nazwa pasma górskiego musi mieć co najmniej 3 litery")
            //    .MaximumLength(25);

            RuleFor(c => c.Elevation)
                .NotEmpty().WithMessage("Przewyższenie musi być wartoscią dodatnią")
                .GreaterThan(0)
                .WithMessage("Przewyższenie musi być wartoscią dodatnią");

            RuleFor(c => c.Length)
                .NotEmpty().WithMessage("Długość trasy musi być wartoscią dodatnią")
                .GreaterThan(0)
                .WithMessage("Długość trasy musi być wartoscią dodatnią");

            RuleFor(c => c.Time)
                .NotEmpty().WithMessage("Czas przejścia musi być wartoscią dodatnią")
                .GreaterThan(0)
                .WithMessage("Czas przejścia musi być wartoscią dodatnią");

            RuleFor(c => c.Level)
                .NotEmpty().WithMessage("Poziom trudności musi być między 1 i 5")
                .GreaterThan(0).WithMessage("Poziom trudności musi być między 1 i 5")
                .LessThanOrEqualTo(5)
                .WithMessage("Poziom trudności musi być między 1 i 5");

            if (!_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                RuleFor(c => c.Email)
                             .NotEmpty()
                             .WithMessage("Adres email użytkownika jest wymagany")
                             .EmailAddress()
                             .WithMessage("Nieprawidłowy adres e-mail");

            }

                  

           



        }
    }
}
