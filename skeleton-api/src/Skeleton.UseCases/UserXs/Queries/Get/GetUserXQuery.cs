using CSharpFunctionalExtensions;
using MediatR;

namespace Skeleton.UseCases.UserXs.Queries.Get;

public record GetUserXQuery(Guid Id) : IRequest<Maybe<GetUserXDto>>;
