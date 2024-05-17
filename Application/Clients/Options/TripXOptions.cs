namespace Application.Clients.Options;

public class TripXOptions
{
    public string BaseAddress { get; set; }

    public Endpoints Endpoints { get; set; }
}

public class Endpoints
{
    public string SearchHotels { get; set; }

    public string SeachFlights { get; set; }
}
