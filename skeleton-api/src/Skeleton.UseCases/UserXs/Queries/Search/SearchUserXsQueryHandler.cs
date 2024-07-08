using MediatR;
using Microsoft.EntityFrameworkCore;
using Skeleton.Infrastructure.Interfaces.Database;

namespace Skeleton.UseCases.UserXs.Queries.Search;

public class SearchUserXsQueryHandler(IReadOnlyDatabaseContext readOnlyDatabaseContext)
    : IRequestHandler<SearchUserXsQuery, IReadOnlyCollection<SearchUserXsDto>>
{
    public async Task<IReadOnlyCollection<SearchUserXsDto>> Handle(
        SearchUserXsQuery request,
        CancellationToken cancellationToken)
    {
        var userXs = await readOnlyDatabaseContext.UserXs
            .Where(x => x.Username.Contains(request.Term))
            .Select(x => new SearchUserXsDto(x.Id, x.Username))
            .ToListAsync(cancellationToken);

        return userXs;
    }
}
