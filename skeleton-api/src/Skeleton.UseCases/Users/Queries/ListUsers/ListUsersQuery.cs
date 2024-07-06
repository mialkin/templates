using MediatR;

namespace Skeleton.UseCases.Users.Queries.ListUsers;

public record ListUsersQuery : IRequest<IReadOnlyCollection<ListUsersDto>>;
