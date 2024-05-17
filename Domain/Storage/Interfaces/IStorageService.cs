using Domain.Entities;

namespace Domain.Storage.Interfaces;

public interface IStorageService
{
    public Task<BookingResponse> StoreBooking(BookingRequest request, int sleepTime);

    public Task<CheckStatusResponse> GetBooking(CheckStatusRequest request);
}
