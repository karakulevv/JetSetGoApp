using Application.Clients.Interfaces;
using Application.Services.Strategy.Interfaces;
using Domain.Entities;

namespace Application.Services.Strategy;

public class SearchStrategy : ISearchStrategy
{
    private ITripXClient _client;

    public SearchStrategy(ITripXClient client)
    {
        _client = client;
    }

    public async Task<SearchResponse> HandleSearch(SearchRequest request)
    {
        ISearchStrategy searchStrategy;
        if (!string.IsNullOrEmpty(request.DepartureAirport))
        {
            searchStrategy = new HotelAndFlightSearchStrategy(_client);
        }
        else
        {
            if ((request.FromDate - DateTime.Now).TotalDays <= 45)
            {
                searchStrategy = new LastMinuteSearchStrategy(_client);
            }
            else
            {
                searchStrategy = new HotelOnlySearchStrategy(_client);
            }
        }
        return await searchStrategy.HandleSearch(request);
    }
}
