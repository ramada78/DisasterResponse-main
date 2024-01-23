using DisasterResponse.Domain;
using DisasterResponse.Domain.Repositories;
using MediatR;

namespace DisasterResponse.Application.Donors.Command.AddAid;

public class AddAidHandler : IRequestHandler<AddAidCommand, Guid>
{
    private readonly IRepository _repository;
    public AddAidHandler(IRepository repository) => _repository = repository;

    public async Task<Guid> Handle(AddAidCommand request, CancellationToken cancellationToken)
    {
        var aid = await _repository.GetById<Aid, Guid>(request.AidId);
        aid.Income(request.DonorId,request.Amount);
        // todo
        await _repository.SaveChangesAsync(cancellationToken);
        return aid.Id;
    }
}