using MediatR;

namespace Skeleton.UseCases.Users.Queries.List;

public record ListUsersQuery : IRequest<IReadOnlyCollection<ListUsersDto>>;
