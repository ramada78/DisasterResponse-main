using DisasterResponse.Application.Donors.Command.Add;
using DisasterResponse.Application.Donors.Command.AddAid;
using DisasterResponse.Application.Donors.Command.Delete;
using DisasterResponse.Application.Donors.Command.Update;
using DisasterResponse.Application.Donors.Queries.GetAll;
using DisasterResponse.Application.Donors.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DisasterResponse.Controllers;

public class DonorController : Controller
{
    private readonly ISender _sender;
    public DonorController(ISender sender) => _sender = sender;

    public async Task<IActionResult> GetAll(int pageIndex, int pageSize)
        => new JsonResult(await _sender.Send(new GetAllDonorsQuery(pageIndex, pageSize)));

    public async Task<IActionResult> GetById(Guid id)
        => new JsonResult(await _sender.Send(new GetDonorByIdQuery(id)));

    public async Task<IActionResult> Add(string name)
        => new JsonResult(await _sender.Send(new AddDonorCommand(name)));

    public async Task<IActionResult> AddAid(AddAidCommand aid)
        => new JsonResult(await _sender.Send(aid));

    public async Task<IActionResult> Update(Guid id, string name)
        => new JsonResult(await _sender.Send(new UpdateDonorCommand(id, name)));

    public async Task<IActionResult> Delete(Guid id)
    {
        await _sender.Send(new DeleteDonorCommand(id));
        return Ok();
    }
}