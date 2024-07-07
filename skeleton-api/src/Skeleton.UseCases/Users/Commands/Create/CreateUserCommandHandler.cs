using CSharpFunctionalExtensions;
using MediatR;
using Skeleton.Domain;
using Skeleton.Domain.Entities;
using Skeleton.Infrastructure.Interfaces.Database;

namespace Skeleton.UseCases.Users.Commands.Create;

internal class CreateUserCommandHandler(IDatabaseContext databaseContext)
    : IRequestHandler<CreateUserCommand, Result<CreateUserDto, Error>>
{
    public async Task<Result<CreateUserDto, Error>> Handle(
        CreateUserCommand request,
        CancellationToken cancellationToken)
    {
        var user = new User { Id = Guid.NewGuid(), Username = request.Username };

        databaseContext.Users.Add(user);

        try
        {
            await databaseContext.SaveChangesAsync(cancellationToken);
        }
        catch (Exception exception)
        {
            if (exception.InnerException != null &&
                exception.InnerException.Message.Contains(
                    "duplicate key value violates unique constraint \"ix_users_username\""))
            {
                return Errors.Word.UsernameAlreadyExists();
            }

            throw;
        }

        return new CreateUserDto(user.Id);
    }
}
