using Application.Clients.Interfaces;
using Application.Clients.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Application.Extensions;
using Newtonsoft.Json;
using Infrastructure.Exceptions;
using SearchOption = Domain.Entities.SearchOption;

namespace Infrastructure.Clients;

public class TripXClient : ITripXClient
{
    private readonly HttpClient _httpClient;
    private readonly ILogger _logger;
    private readonly TripXOptions _options;

    public TripXClient(HttpClient httpClient, ILogger<TripXClient> logger, IOptions<TripXOptions> options)
    {
        _httpClient = httpClient;
        _logger = logger;
        _options = options.Value;
    }

    public async Task<List<SearchOption>> SearchFlightsAsync(string departureAirport, string arrivalAirport)
    {
        HttpResponseMessage httpResponse = new HttpResponseMessage();
        try
        {
            string interpolatedUrl = _options.Endpoints.SeachFlights.Interpolate(departureAirport, arrivalAirport);
            httpResponse = await _httpClient.GetAsync(interpolatedUrl);

            string content = await httpResponse.Content.ReadAsStringAsync();
            if (httpResponse.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<SearchOption>>(content)!;
            }

            _logger.LogWarning(content);
            throw new HttpRequestException("Non-success status code received.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Request to TripX API failed.");
            throw new HttpResponseException("Request to TripX API failed.", httpResponse.StatusCode);
        }
    }

    public async Task<List<SearchOption>> SearchHotelsAsync(string destinationCode)
    {
        HttpResponseMessage httpResponse = new HttpResponseMessage();
        try
        {
            string interpolatedUrl = _options.Endpoints.SearchHotels.Interpolate(destinationCode);
            httpResponse = await _httpClient.GetAsync(interpolatedUrl);

            string content = await httpResponse.Content.ReadAsStringAsync();
            if (httpResponse.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<SearchOption>>(content)!;
            }

            _logger.LogWarning(content);
            throw new HttpRequestException("Non-success status code received.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Request to TripX API failed.");
            throw new HttpResponseException("Request to TripX API failed.", httpResponse.StatusCode);
        }
    }
}
