using MediatR;

namespace Skeleton.UseCases.UserTemplates.Queries.List;

public record ListUserTemplatesQuery : IRequest<IReadOnlyCollection<ListUserTemplatesDto>>;
