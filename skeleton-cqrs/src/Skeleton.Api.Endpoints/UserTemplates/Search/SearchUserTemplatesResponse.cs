using Skeleton.UseCases.UserTemplates.Queries.Search;

namespace Skeleton.Api.Endpoints.UserTemplates.Search;

public record SearchUserTemplatesResponse(IReadOnlyCollection<SearchUserTemplatesDto> UserTemplates);
