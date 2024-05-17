using FluentValidation;

namespace Domain.Entities;

public class SearchRequest
{
    public string DestinationAirport { get; set; }
    public string? DepartureAirport { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
}

public class SearchRequestValidator : AbstractValidator<SearchRequest>
{
    public SearchRequestValidator()
    {
        RuleFor(x => x).NotNull();
        RuleFor(x => x.DestinationAirport).NotEmpty().NotNull();
        RuleFor(x => x.FromDate).NotEmpty().NotNull();
        RuleFor(x => x.ToDate).NotEmpty().NotNull();
    }
}
