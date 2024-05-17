using FluentValidation;

namespace Domain.Entities;

public class CheckStatusRequest
{
    public string BookingCode { get; set; }

    public CheckStatusRequest(string bookingCode)
    {
        BookingCode = bookingCode;
    }
}

public class CheckStatusRequestValidator : AbstractValidator<CheckStatusRequest>
{
    public CheckStatusRequestValidator()
    {
        RuleFor(x => x).NotNull();
        RuleFor(x => x.BookingCode).NotEmpty().NotNull();
    }
}
