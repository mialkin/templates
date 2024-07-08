using CSharpFunctionalExtensions;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Skeleton.Infrastructure.Interfaces.Database;

namespace Skeleton.UseCases.UserTemplates.Queries.Get;

internal class GetUserTemplateQueryHandler(IReadOnlyDatabaseContext readOnlyDatabaseContext)
    : IRequestHandler<GetUserTemplateQuery, Maybe<GetUserTemplateDto>>
{
    public async Task<Maybe<GetUserTemplateDto>> Handle(GetUserTemplateQuery request, CancellationToken cancellationToken)
    {
        var userTemplate = await readOnlyDatabaseContext.UserTemplates.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        return userTemplate is null ? Maybe.None : Maybe.From(userTemplate.Adapt<GetUserTemplateDto>());
    }
}
