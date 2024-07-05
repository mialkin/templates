using CSharpFunctionalExtensions;
using MediatR;
using Skeleton.Domain;

namespace Skeleton.UseCases.Users.Commands.CreateUser;

public record CreateUserCommand(string Username) : IRequest<Result<CreateUserDto, Error>>;
