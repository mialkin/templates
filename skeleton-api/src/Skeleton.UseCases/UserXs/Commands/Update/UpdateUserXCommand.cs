using CSharpFunctionalExtensions;
using MediatR;
using Skeleton.Domain;

namespace Skeleton.UseCases.UserXs.Commands.Update;

public record UpdateUserXCommand(Guid Id, string Name) : IRequest<UnitResult<Error>>;
