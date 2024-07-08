using MediatR;

namespace Skeleton.UseCases.UserTemplates.Queries.Search;

public record SearchUserTemplatesQuery(string Term) : IRequest<IReadOnlyCollection<SearchUserTemplatesDto>>;
