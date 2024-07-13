using MediatR;

namespace Skeleton.UseCases.UserTemplates.Commands.Delete;

public record DeleteUserTemplateCommand(Guid Id) : IRequest;
