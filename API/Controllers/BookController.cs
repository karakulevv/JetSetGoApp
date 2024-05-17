using Application.Interfaces;
using Domain.Entities;
using JetSetGo.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JetSetGo.Controllers;

[ApiController]
[Route("[controller]")]
[AuthorizeApiKeyAttribute]
public class BookController : ControllerBase
{
    private readonly IManager _manager;

    public BookController(IManager manager)
    {
        _manager = manager;
    }

    [HttpPost]
    public async Task<IActionResult> Book(BookingRequest request)
    {
        var result = await _manager.Book(request);
        return Ok(result);
    }
}
