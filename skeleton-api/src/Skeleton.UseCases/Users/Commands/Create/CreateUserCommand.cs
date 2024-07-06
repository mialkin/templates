using CSharpFunctionalExtensions;
using MediatR;
using Skeleton.Domain;

namespace Skeleton.UseCases.Users.Commands.Create;

public record CreateUserCommand(string Username) : IRequest<Result<CreateUserDto, Error>>;
