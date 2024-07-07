using MediatR;
using Microsoft.EntityFrameworkCore;
using Skeleton.Infrastructure.Interfaces.Database;

namespace Skeleton.UseCases.Users.Queries.Search;

public class SearchUsersQueryHandler(IReadOnlyDatabaseContext readOnlyDatabaseContext)
    : IRequestHandler<SearchUsersQuery, IReadOnlyCollection<SearchUsersDto>>
{
    public async Task<IReadOnlyCollection<SearchUsersDto>> Handle(
        SearchUsersQuery request,
        CancellationToken cancellationToken)
    {
        var users = await readOnlyDatabaseContext.Users
            .Where(x => x.Username.Contains(request.Term))
            .Select(x => new SearchUsersDto(x.Id, x.Username))
            .ToListAsync(cancellationToken);

        return users;
    }
}
