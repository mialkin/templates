using CSharpFunctionalExtensions;
using MediatR;
using Skeleton.Domain;

namespace Skeleton.UseCases.Users.Commands.Update;

public record UpdateUserCommand(Guid Id, string Username) : IRequest<UnitResult<Error>>;
