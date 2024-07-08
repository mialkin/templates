using MediatR;

namespace Skeleton.UseCases.UserXs.Queries.Search;

public record SearchUserXsQuery(string Term) : IRequest<IReadOnlyCollection<SearchUserXsDto>>;
