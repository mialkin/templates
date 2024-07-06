using MediatR;
using Microsoft.EntityFrameworkCore;
using Skeleton.Infrastructure.Interfaces.Database;

namespace Skeleton.UseCases.Users.Queries.ListUsers;

internal class ListUsersQueryHandler(IReadOnlyDatabaseContext readOnlyDatabaseContext)
    : IRequestHandler<ListUsersQuery, IReadOnlyCollection<ListUsersDto>>
{
    public async Task<IReadOnlyCollection<ListUsersDto>> Handle(
        ListUsersQuery request,
        CancellationToken cancellationToken)
    {
        var users = await readOnlyDatabaseContext.Users
            .Select(x => new ListUsersDto(x.Id, x.Username))
            .ToListAsync(cancellationToken);

        return users;
    }
}
