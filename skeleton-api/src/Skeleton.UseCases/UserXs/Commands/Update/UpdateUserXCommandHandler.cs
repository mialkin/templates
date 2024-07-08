using CSharpFunctionalExtensions;
using MediatR;
using Skeleton.Domain;
using Skeleton.Infrastructure.Interfaces.Database;

namespace Skeleton.UseCases.UserXs.Commands.Update;

internal class UpdateUserXCommandHandler(
    IDatabaseContext databaseContext,
    IDatabaseErrorMessagesProvider databaseErrorMessagesProvider)
    : IRequestHandler<UpdateUserXCommand, UnitResult<Error>>
{
    public async Task<UnitResult<Error>> Handle(UpdateUserXCommand request, CancellationToken cancellationToken)
    {
        var userX = await databaseContext.UserXs.FindAsync(request.Id, cancellationToken);
        if (userX is null)
        {
            return UnitResult.Failure(Errors.General.NotFound());
        }

        userX.Name = request.Name;

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

        return UnitResult.Success<Error>();
    }
}
