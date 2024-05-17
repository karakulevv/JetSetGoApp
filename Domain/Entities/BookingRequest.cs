using FluentValidation;

namespace Domain.Entities;

public class BookingRequest
{
    public string OptionCode { get; set; }
    public SearchRequest SearchRequest { get; set; }
}

public class BookingRequestValidator : AbstractValidator<BookingRequest>
{
    public BookingRequestValidator()
    {
        RuleFor(x => x).NotNull();
        RuleFor(x => x.OptionCode).NotEmpty().NotNull();
        RuleFor(x => x.SearchRequest).NotNull();
        RuleFor(x => x.SearchRequest.DestinationAirport).NotEmpty().NotNull();
        RuleFor(x => x.SearchRequest.FromDate).NotEmpty().NotNull();
        RuleFor(x => x.SearchRequest.ToDate).NotEmpty().NotNull();
    }
}