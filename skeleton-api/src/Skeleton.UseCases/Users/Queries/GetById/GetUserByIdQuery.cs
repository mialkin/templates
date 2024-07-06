using CSharpFunctionalExtensions;
using MediatR;

namespace Skeleton.UseCases.Users.Queries.GetById;

public record GetUserByIdQuery(Guid Id) : IRequest<Maybe<GetUserByIdDto>>;
