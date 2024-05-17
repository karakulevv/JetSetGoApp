using Application.Clients.Interfaces;
using Application.Helpers;
using Application.Services.Strategy.Interfaces;
using Domain.Entities;
using SearchOption = Domain.Entities.SearchOption;

namespace Application.Services.Strategy;

public class LastMinuteSearchStrategy : ISearchStrategy
{
    private readonly ITripXClient _client;
    public LastMinuteSearchStrategy(ITripXClient client)
    {
        _client = client;
    }

    public async Task<SearchResponse> HandleSearch(SearchRequest request)
    {
        List<SearchOption> hotelResponse = await _client.SearchHotelsAsync(request.DestinationAirport);

        var listResponse = new SearchResponse();

        foreach (var hotelOption in hotelResponse)
        {
            SearchOption option = new SearchOption(
                hotelOption.Price,
                RandomCodeHelper.GenerateRandomCode(6),
                hotelOption.HotelCode,
                string.Empty,
                request.DestinationAirport
            );

            listResponse.Options.Add(option);
        }

        return listResponse;
    }
}
