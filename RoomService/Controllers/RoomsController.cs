using Microsoft.AspNetCore.Mvc;
using RoomService.Data.Models;
using RoomService.Interfaces;

namespace RoomService.Controllers;

[Route("api/[controller]")]
public class RoomsController(IRoomService roomService) : BaseController
{
    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> GetRoom(Guid id)
    {
        var result = await roomService.GetRoom(id);
        return BuildEnvelope(result);
    }

    [HttpGet]
    [ProducesResponseType(200)]
    public async Task<IActionResult> GetRooms([FromQuery] GetRoomsRequestModel request)
    {
        var result = await roomService.GetRooms(request);
        return BuildEnvelope(result);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> UpdateRoom(Guid id, UpdateRoomRequestModel request)
    {
        var result = await roomService.UpdateRoom(id, request);
        return BuildEnvelope(result);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    public async Task<IActionResult> CreateRoom(CreateRoomRequestModel request)
    {
        var result = await roomService.CreateRoom(request);
        return BuildEnvelope(result);
    }

}
