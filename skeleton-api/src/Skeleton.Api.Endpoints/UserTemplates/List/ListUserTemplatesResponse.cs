using Skeleton.UseCases.UserTemplates.Queries.List;

namespace Skeleton.Api.Endpoints.UserTemplates.List;

public record ListUserTemplatesResponse(IReadOnlyCollection<ListUserTemplatesDto> UserTemplates);
