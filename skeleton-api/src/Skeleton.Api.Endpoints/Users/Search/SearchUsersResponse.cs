using Skeleton.UseCases.Users.Queries.Search;

namespace Skeleton.Api.Endpoints.Users.Search;

public record SearchUsersResponse(IReadOnlyCollection<SearchUsersDto> Users);
