using MediatR;

namespace Skeleton.UseCases.UserXs.Commands.Delete;

public record DeleteUserXCommand(Guid Id) : IRequest;
