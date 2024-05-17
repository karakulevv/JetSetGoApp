using Domain.Entities;
using SearchOption = Domain.Entities.SearchOption;

namespace Application.Clients.Interfaces;

public interface ITripXClient
{
    public Task<List<SearchOption>> SearchHotelsAsync(string destinationCode);
    public Task<List<SearchOption>> SearchFlightsAsync(string departureAirport, string arrivalAirport);
}
