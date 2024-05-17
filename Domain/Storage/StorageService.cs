using Domain.Cache.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Domain.Storage.Interfaces;

namespace Domain.Storage;

public class StorageService : IStorageService
{
    private readonly ICache _cache;
    private const string cacheKey = "storage_key";

    public StorageService(ICache cache)
    {
        _cache = cache;
    }

    public async Task<CheckStatusResponse> GetBooking(CheckStatusRequest request)
    {
       
        var booking = await _cache.GetAsync<BookingDto>($"{cacheKey}_{request.BookingCode}");

        if (booking != null)
        {
            if (DateTime.Now < booking.SleepTime)
                return new CheckStatusResponse(BookingStatusEnum.Pending);

            return new CheckStatusResponse(BookingStatusEnum.Success);
        }

        return new CheckStatusResponse(BookingStatusEnum.Failed);        
    }

    public async Task<BookingResponse> StoreBooking(BookingRequest request, int sleepTime)
    {
        BookingDto bookingModel = new BookingDto(request, request.OptionCode, DateTime.Now.AddMinutes(sleepTime));

        // cache expiry set to 24 hours
        await _cache.Set<BookingDto>($"{cacheKey}_{request.OptionCode}", bookingModel, TimeSpan.FromHours(24)); 

        return new BookingResponse(request.OptionCode, bookingModel.CreationDate);
    }    
}
