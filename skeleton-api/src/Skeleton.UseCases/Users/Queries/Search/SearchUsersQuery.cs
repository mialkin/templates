using MediatR;

namespace Skeleton.UseCases.Users.Queries.Search;

public record SearchUsersQuery(string Term) : IRequest<IReadOnlyCollection<SearchUsersDto>>;
