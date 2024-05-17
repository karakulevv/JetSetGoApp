using Domain.Enums;

namespace Domain.Entities;

public class CheckStatusResponse
{
    public BookingStatusEnum Status { get; set; }

    public CheckStatusResponse(BookingStatusEnum status)
    {
        Status = status;
    }
}
