using MediatR;

namespace DisasterResponse.Application.AffectedIndividuals.Commands.Delete;

public class DeleteIndividualAffectedCommand : IRequest
{
    public Guid Id { get; set; }
}