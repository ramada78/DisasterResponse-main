using DisasterResponse.Application.Request.Add;
using DisasterResponse.Application.Request.Commands.Handle;
using DisasterResponse.Application.Request.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DisasterResponse.Controllers;

public class RequestController : Controller
{
    private readonly ISender _sender;
    public RequestController(ISender sender) => _sender = sender;

    public async Task<IActionResult> GetAll(int pageIndex, int pageSize)
        => new JsonResult(await _sender.Send(new GetAllAidRequestsQuery(pageIndex, pageSize)));

    public async Task<IActionResult> Add(Guid individualAffectedId)
        => new JsonResult(await _sender.Send(new AddRequestCommand(individualAffectedId)));

    public async Task<IActionResult> Handle(Guid id, Guid aidId, int amount)
        => new JsonResult(await _sender.Send(new HandleAidRequestCommand(id, aidId, amount)));
}