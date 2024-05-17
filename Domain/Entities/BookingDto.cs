namespace Domain.Entities;

public class BookingDto
{
    public string BookingCode { get; set; }

    public DateTime CreationDate { get; set; }

    public string Destination { get; set; }

    public string Departure { get; set; }

    public DateTime FromDate { get; set; }

    public DateTime ToDate { get; set; }

    public DateTime SleepTime { get; set; }

    public BookingDto(BookingRequest request, string bookingCode, DateTime sleepTime)
    {
        BookingCode = bookingCode;
        CreationDate = DateTime.Now;
        Destination = request.SearchRequest.DestinationAirport;
        Departure = request.SearchRequest.DestinationAirport;
        FromDate = request.SearchRequest.FromDate;
        ToDate = request.SearchRequest.ToDate;
        SleepTime = sleepTime;
    }
}
