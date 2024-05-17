using Domain.Entities;

namespace Application.Interfaces;

public interface IManager
{
    public Task<SearchResponse> Search(SearchRequest request);
    public Task<BookingResponse> Book(BookingRequest request);
    public Task<CheckStatusResponse> CheckStatus(CheckStatusRequest request);
}
