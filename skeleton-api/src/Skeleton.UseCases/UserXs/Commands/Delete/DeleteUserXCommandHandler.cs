using MediatR;
using Microsoft.EntityFrameworkCore;
using Skeleton.Infrastructure.Interfaces.Database;

namespace Skeleton.UseCases.UserXs.Commands.Delete;

internal class DeleteUserXCommandHandler(IDatabaseContext databaseContext)
    : IRequestHandler<DeleteUserXCommand>
{
    public async Task Handle(DeleteUserXCommand request, CancellationToken cancellationToken)
    {
        await databaseContext.UserXs.Where(x => x.Id == request.Id)
            .ExecuteDeleteAsync(cancellationToken: cancellationToken);
    }
}
