namespace Domain.Entities;

public class SearchResponse
{
    public List<SearchOption> Options { get; set; } = new List<SearchOption>();

    public SearchResponse() { }    

    public SearchResponse(List<SearchOption> searchOptions)
    {
        Options = searchOptions;
    }
}

public class SearchOption
{
    public string OptionCode { get; set; }
    public string HotelCode { get; set; }
    public string FlightCode { get; set; }
    public string ArrivalAirport { get; set; }
    public double Price { get; set; }

    public SearchOption(double price, string optionCode, string? hotelCode = null, string? flightCode = null, string? arrivalAirport = null)
    {
        Price += price;
        OptionCode = optionCode;
        HotelCode = hotelCode ?? string.Empty;
        FlightCode = flightCode ?? string.Empty;
        ArrivalAirport = arrivalAirport ?? string.Empty;
    }
}
