using Skeleton.UseCases.UserXs.Queries.Search;

namespace Skeleton.Api.Endpoints.UserXs.Search;

public record SearchUserXsResponse(IReadOnlyCollection<SearchUserXsDto> UserXs);
