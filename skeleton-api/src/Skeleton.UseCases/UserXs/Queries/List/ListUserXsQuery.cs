using MediatR;

namespace Skeleton.UseCases.UserXs.Queries.List;

public record ListUserXsQuery : IRequest<IReadOnlyCollection<ListUserXsDto>>;
