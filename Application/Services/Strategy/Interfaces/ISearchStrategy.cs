using Domain.Entities;
using SearchOption = Domain.Entities.SearchOption;

namespace Application.Services.Strategy.Interfaces;

public interface ISearchStrategy
{
    public Task<SearchResponse> HandleSearch(SearchRequest request);
}
