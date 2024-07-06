using Skeleton.UseCases.Users.Queries.List;

namespace Skeleton.Api.Endpoints.Users.List;

public record ListUsersResponse(IReadOnlyCollection<ListUsersDto> Users);
