using CSharpFunctionalExtensions;
using MediatR;
using Skeleton.Domain;

namespace Skeleton.UseCases.UserTemplates.Commands.Update;

public record UpdateUserTemplateCommand(Guid Id, string Name) : IRequest<UnitResult<Error>>;
