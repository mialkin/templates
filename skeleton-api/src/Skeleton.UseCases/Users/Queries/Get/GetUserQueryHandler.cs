using CSharpFunctionalExtensions;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Skeleton.Infrastructure.Interfaces.Database;

namespace Skeleton.UseCases.Users.Queries.Get;

internal class GetUserQueryHandler(IReadOnlyDatabaseContext readOnlyDatabaseContext)
    : IRequestHandler<GetUserQuery, Maybe<GetUserDto>>
{
    public async Task<Maybe<GetUserDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await readOnlyDatabaseContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        return user is null ? Maybe.None : Maybe.From(user.Adapt<GetUserDto>());
    }
}
