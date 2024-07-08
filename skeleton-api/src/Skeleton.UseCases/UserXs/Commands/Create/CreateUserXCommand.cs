using CSharpFunctionalExtensions;
using MediatR;
using Skeleton.Domain;

namespace Skeleton.UseCases.UserXs.Commands.Create;

public record CreateUserXCommand(string Name) : IRequest<Result<CreateUserXDto, Error>>;
