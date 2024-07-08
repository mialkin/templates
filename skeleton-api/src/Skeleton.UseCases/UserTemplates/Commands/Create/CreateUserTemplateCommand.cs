using CSharpFunctionalExtensions;
using MediatR;
using Skeleton.Domain;

namespace Skeleton.UseCases.UserTemplates.Commands.Create;

public record CreateUserTemplateCommand(string Name) : IRequest<Result<CreateUserTemplateDto, Error>>;
