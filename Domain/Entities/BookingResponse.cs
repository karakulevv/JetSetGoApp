namespace Domain.Entities;

public class BookingResponse
{
    public string BookingCode { get; set; }
    public DateTime BookingTime { get; set; }

    public BookingResponse(string bookingCode, DateTime bookingTime)
    {
        BookingCode = bookingCode;
        BookingTime = bookingTime;
    }
}
