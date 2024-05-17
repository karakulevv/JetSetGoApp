using Application.Interfaces;
using Domain.Entities;
using JetSetGo.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JetSetGo.Controllers;

[ApiController]
[Route("[controller]")]
[AuthorizeApiKeyAttribute]
public class SearchController : ControllerBase
{
    private readonly IManager _manager;

    public SearchController(IManager manager)
    {
        _manager = manager;
    }

    [HttpPost]
    public async Task<IActionResult> Search(SearchRequest request)
    {
        var result = await _manager.Search(request);
        return Ok(result);
    }
}
