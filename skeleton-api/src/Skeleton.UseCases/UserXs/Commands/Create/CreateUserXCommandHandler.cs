using CSharpFunctionalExtensions;
using MediatR;
using Skeleton.Domain;
using Skeleton.Domain.Entities;
using Skeleton.Infrastructure.Interfaces.Database;

namespace Skeleton.UseCases.UserXs.Commands.Create;

internal class CreateUserXCommandHandler(
    IDatabaseContext databaseContext,
    IDatabaseErrorMessagesProvider databaseErrorMessagesProvider)
    : IRequestHandler<CreateUserXCommand, Result<CreateUserXDto, Error>>
{
    public async Task<Result<CreateUserXDto, Error>> Handle(
        CreateUserXCommand request,
        CancellationToken cancellationToken)
    {
        var userX = new UserX { Id = Guid.NewGuid(), Name = request.Name };

        databaseContext.UserXs.Add(userX);

        try
        {
            await databaseContext.SaveChangesAsync(cancellationToken);
        }
        catch (Exception exception)
        {
            if (exception.InnerException != null &&
                exception.InnerException.Message.Contains(databaseErrorMessagesProvider.UserXNameUniquenessViolation))
            {
                return Errors.Word.NameAlreadyExists();
            }

            throw;
        }

        return new CreateUserXDto(userX.Id);
    }
}
