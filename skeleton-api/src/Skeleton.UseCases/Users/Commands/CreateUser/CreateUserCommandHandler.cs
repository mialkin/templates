using CSharpFunctionalExtensions;
using MediatR;
using Skeleton.Domain;
using Skeleton.Domain.Entities;
using Skeleton.Infrastructure.Interfaces.Database;

namespace Skeleton.UseCases.Users.Commands.CreateUser;

internal class CreateUserCommandHandler(IDatabaseContext databaseContext)
    : IRequestHandler<CreateUserCommand, Result<CreateUserDto, Error>>
{
    public async Task<Result<CreateUserDto, Error>> Handle(
        CreateUserCommand request,
        CancellationToken cancellationToken)
    {
        var user = new User { Id = Guid.NewGuid(), Username = request.Username };

        databaseContext.Users.Add(user);

        await databaseContext.SaveChangesAsync(cancellationToken);

        return new CreateUserDto(user.Id);
    }
}
