using Application.Interfaces;
using Domain.Entities;
using JetSetGo.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace JetSetGo.Controllers;

[ApiController]
[Route("[controller]")]
[AuthorizeApiKeyAttribute]
public class CheckStatusController : ControllerBase
{
    private readonly IManager _manager;

    public CheckStatusController(IManager manager)
    {
        _manager = manager;
    }

    [HttpGet("{bookingCode}")]
    public async Task<IActionResult> CheckStatus([Required] string bookingCode)
    {
        var result = await _manager.CheckStatus(new CheckStatusRequest(bookingCode));
        return Ok(result);
    }
}