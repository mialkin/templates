using CSharpFunctionalExtensions;
using MediatR;

namespace Skeleton.UseCases.Users.Queries.Get;

public record GetUserQuery(Guid Id) : IRequest<Maybe<GetUserDto>>;
