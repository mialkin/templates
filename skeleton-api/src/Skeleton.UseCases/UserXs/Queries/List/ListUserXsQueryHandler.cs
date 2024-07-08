using MediatR;
using Microsoft.EntityFrameworkCore;
using Skeleton.Infrastructure.Interfaces.Database;

namespace Skeleton.UseCases.UserXs.Queries.List;

internal class ListUserXsQueryHandler(IReadOnlyDatabaseContext readOnlyDatabaseContext)
    : IRequestHandler<ListUserXsQuery, IReadOnlyCollection<ListUserXsDto>>
{
    public async Task<IReadOnlyCollection<ListUserXsDto>> Handle(
        ListUserXsQuery request,
        CancellationToken cancellationToken)
    {
        var userXs = await readOnlyDatabaseContext.UserXs
            .Select(x => new ListUserXsDto(x.Id, x.Username))
            .ToListAsync(cancellationToken);

        return userXs;
    }
}
