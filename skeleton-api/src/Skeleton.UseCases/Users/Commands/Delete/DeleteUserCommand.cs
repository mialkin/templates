using MediatR;

namespace Skeleton.UseCases.Users.Commands.Delete;

public record DeleteUserCommand(Guid Id) : IRequest;
