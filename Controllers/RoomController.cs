using Microsoft.AspNetCore.Mvc;
using PrepT2.Services;
using T2.DTOs;

namespace T2.Controllers;

[ApiController]
[Route("api")]
public class GeneralController(IDbService service): ControllerBase
{
    
    [HttpGet]
    [Route("rooms/{roomId::int}/guests")]
    public async Task<IActionResult> GetHistoryForRoomWithId(int roomId)
    {
        var res = await service.GetHistoryForRoomWithId(roomId);
        if (res == null)
        {
            return NotFound();
        }
        return Ok(res);
    }

    [HttpPost]
    [Route("guests")]
    public async Task<IActionResult> CreateGuest([FromBody]GuestWithReservationDTO guest)
    {
        var res = await service.CreateGuest(guest);
        if (!res.Item1)
        {
            return BadRequest(res.Item2);
        }
        return Created();
    }
    
    
}