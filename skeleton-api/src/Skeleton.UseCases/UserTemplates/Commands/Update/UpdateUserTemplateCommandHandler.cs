using CSharpFunctionalExtensions;
using MediatR;
using Skeleton.Domain;
using Skeleton.Infrastructure.Interfaces.Database;

namespace Skeleton.UseCases.UserTemplates.Commands.Update;

internal class UpdateUserTemplateCommandHandler(
    IDatabaseContext databaseContext,
    IDatabaseErrorMessagesProvider databaseErrorMessagesProvider)
    : IRequestHandler<UpdateUserTemplateCommand, UnitResult<Error>>
{
    public async Task<UnitResult<Error>> Handle(UpdateUserTemplateCommand request, CancellationToken cancellationToken)
    {
        var userTemplate = await databaseContext.UserTemplates.FindAsync(request.Id, cancellationToken);
        if (userTemplate is null)
        {
            return UnitResult.Failure(Errors.General.NotFound());
        }

        userTemplate.Name = request.Name;

        try
        {
            await databaseContext.SaveChangesAsync(cancellationToken);
        }
        catch (Exception exception)
        {
            if (exception.InnerException != null &&
                exception.InnerException.Message
                    .Contains(databaseErrorMessagesProvider.UserTemplateNameUniquenessViolation))
            {
                return Errors.UserTemplate.NameAlreadyExists();
            }

            throw;
        }

        return UnitResult.Success<Error>();
    }
}
