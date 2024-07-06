using CSharpFunctionalExtensions;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Skeleton.Infrastructure.Interfaces.Database;

namespace Skeleton.UseCases.Users.Queries.GetById;

internal class GetUserByIdQueryHandler(IReadOnlyDatabaseContext readOnlyDatabaseContext)
    : IRequestHandler<GetUserByIdQuery, Maybe<GetUserByIdDto>>
{
    public async Task<Maybe<GetUserByIdDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await readOnlyDatabaseContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        return user is null ? Maybe.None : Maybe.From(user.Adapt<GetUserByIdDto>());
    }
}
