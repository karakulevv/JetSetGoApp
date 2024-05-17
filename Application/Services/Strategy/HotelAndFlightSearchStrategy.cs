using Application.Clients.Interfaces;
using Application.Helpers;
using Application.Services.Strategy.Interfaces;
using Domain.Entities;
using SearchOption = Domain.Entities.SearchOption;

namespace Application.Services.Strategy;

public class HotelAndFlightSearchStrategy : ISearchStrategy
{
    private readonly ITripXClient _client;

    public HotelAndFlightSearchStrategy(ITripXClient client)
    {
        _client = client;
    }

    public async Task<SearchResponse> HandleSearch(SearchRequest request)
    {
        List<SearchOption> flightResponse = await _client.SearchFlightsAsync(request.DepartureAirport!, request.DestinationAirport);

        List<SearchOption> hotelResponse = await _client.SearchHotelsAsync(request.DestinationAirport);

        var combinedResponse = new SearchResponse();

        foreach (var hotelOption in hotelResponse)
        {
            foreach (var flightOption in flightResponse)
            {
                var combinedOption = new SearchOption(
                    hotelOption.Price + flightOption.Price,
                    RandomCodeHelper.GenerateRandomCode(6),
                    hotelOption.HotelCode,
                    flightOption.FlightCode,
                    request.DestinationAirport
                );

                combinedResponse.Options.Add(combinedOption);
            }
        }

        return combinedResponse;        
    }
}
