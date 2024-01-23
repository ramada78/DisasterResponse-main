using DisasterResponse.Application.AffectedIndividuals.Commands.Add;
using DisasterResponse.Application.AffectedIndividuals.Commands.Delete;
using DisasterResponse.Application.AffectedIndividuals.Commands.Update;
using DisasterResponse.Application.AffectedIndividuals.Queries.GetAll;
using DisasterResponse.Application.AffectedIndividuals.Queries.GetById;
using DisasterResponse.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DisasterResponse.Controllers;

public class IndividualsAffectedController : Controller
{
    private readonly ISender _sender;
    public IndividualsAffectedController(ISender sender) => _sender = sender;

    public async Task<IActionResult> GetAll(int pageIndex, int pageSize)
        => new JsonResult(await _sender.Send(new GetAllIndividualAffectedQuery(pageIndex, pageSize)));

    public async Task<IActionResult> GetById(Guid id)
        => new JsonResult(await _sender.Send(new GetIndividualAffectedByIdQuery(id)));

    public async Task<IActionResult> Add(string name, DateOnly birthDate, List<DamageCase> damageCases)
        => new JsonResult(await _sender.Send(new AddIndividualAffectedCommand(name, birthDate, damageCases)));

    public async Task<IActionResult> Update(Guid id, string name, DateOnly birthDate)
        => new JsonResult(await _sender.Send(new UpdateIndividualsAffectedCommand(id, name, birthDate)));

    public async Task<IActionResult> Delete(Guid id)
    {
        await _sender.Send(new DeleteIndividualAffectedCommand());
        return Ok();
    }
}