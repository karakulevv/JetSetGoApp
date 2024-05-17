using Application.Clients.Interfaces;
using Application.Interfaces;
using Application.Services.Strategy;
using Application.Services.Strategy.Interfaces;
using Domain.Entities;
using Domain.Storage.Interfaces;

namespace Application.Services;

public class Manager : IManager
{
    private ITripXClient _client;
    private IStorageService _storage;

    public Manager(ITripXClient client, IStorageService storage)
    {
        _client = client;
        _storage = storage;
    }

    public async Task<BookingResponse> Book(BookingRequest request)
    {
        Random random = new Random();
        int minValue = 30;
        int maxValue = 61; // maxValue is exclusive, so use 61 to include 60
        int randomSleepNumber = random.Next(minValue, maxValue);

        return await _storage.StoreBooking(request, randomSleepNumber);        
    }

    public async Task<CheckStatusResponse> CheckStatus(CheckStatusRequest request)
    {
        return await _storage.GetBooking(request);
    }

    public async Task<SearchResponse> Search(SearchRequest request)
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
