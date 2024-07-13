using MediatR;
using Microsoft.EntityFrameworkCore;
using Skeleton.Infrastructure.Interfaces.Database;

namespace Skeleton.UseCases.UserTemplates.Queries.Search;

public class SearchUserTemplatesQueryHandler(IReadOnlyDatabaseContext readOnlyDatabaseContext)
    : IRequestHandler<SearchUserTemplatesQuery, IReadOnlyCollection<SearchUserTemplatesDto>>
{
    public async Task<IReadOnlyCollection<SearchUserTemplatesDto>> Handle(
        SearchUserTemplatesQuery request,
        CancellationToken cancellationToken)
    {
        var userTemplates = await readOnlyDatabaseContext.UserTemplates
            .Where(x => x.Name.Contains(request.Term))
            .Select(x => new SearchUserTemplatesDto(x.Id, x.Name))
            .ToListAsync(cancellationToken);

        return userTemplates;
    }
}
