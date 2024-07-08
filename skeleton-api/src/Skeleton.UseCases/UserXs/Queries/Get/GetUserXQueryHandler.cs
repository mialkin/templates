using CSharpFunctionalExtensions;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Skeleton.Infrastructure.Interfaces.Database;

namespace Skeleton.UseCases.UserXs.Queries.Get;

internal class GetUserXQueryHandler(IReadOnlyDatabaseContext readOnlyDatabaseContext)
    : IRequestHandler<GetUserXQuery, Maybe<GetUserXDto>>
{
    public async Task<Maybe<GetUserXDto>> Handle(GetUserXQuery request, CancellationToken cancellationToken)
    {
        var userX = await readOnlyDatabaseContext.UserXs.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        return userX is null ? Maybe.None : Maybe.From(userX.Adapt<GetUserXDto>());
    }
}
