using Skeleton.UseCases.UserXs.Queries.List;

namespace Skeleton.Api.Endpoints.UserXs.List;

public record ListUserXsResponse(IReadOnlyCollection<ListUserXsDto> UserXs);
