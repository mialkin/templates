using MediatR;
using Microsoft.EntityFrameworkCore;
using Skeleton.Infrastructure.Interfaces.Database;

namespace Skeleton.UseCases.UserTemplates.Queries.List;

internal class ListUserTemplatesQueryHandler(IReadOnlyDatabaseContext readOnlyDatabaseContext)
    : IRequestHandler<ListUserTemplatesQuery, IReadOnlyCollection<ListUserTemplatesDto>>
{
    public async Task<IReadOnlyCollection<ListUserTemplatesDto>> Handle(
        ListUserTemplatesQuery request,
        CancellationToken cancellationToken)
    {
        var userTemplates = await readOnlyDatabaseContext.UserTemplates
            .Select(x => new ListUserTemplatesDto(x.Id, x.Name))
            .ToListAsync(cancellationToken);

        return userTemplates;
    }
}
