using MediatR;
using Microsoft.EntityFrameworkCore;
using Skeleton.Infrastructure.Interfaces.Database;

namespace Skeleton.UseCases.UserTemplates.Commands.Delete;

internal class DeleteUserTemplateCommandHandler(IDatabaseContext databaseContext)
    : IRequestHandler<DeleteUserTemplateCommand>
{
    public async Task Handle(DeleteUserTemplateCommand request, CancellationToken cancellationToken)
    {
        await databaseContext.UserTemplates.Where(x => x.Id == request.Id)
            .ExecuteDeleteAsync(cancellationToken: cancellationToken);
    }
}
