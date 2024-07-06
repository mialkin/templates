using Skeleton.UseCases.Users.Queries.ListUsers;

namespace Skeleton.Api.Endpoints.Users.List;

public record ListUsersResponse(IReadOnlyCollection<ListUsersDto> Users);
