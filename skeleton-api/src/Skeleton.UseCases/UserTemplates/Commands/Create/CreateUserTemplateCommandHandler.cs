using CSharpFunctionalExtensions;
using MediatR;
using Skeleton.Domain;
using Skeleton.Domain.Entities;
using Skeleton.Infrastructure.Interfaces.Database;

namespace Skeleton.UseCases.UserTemplates.Commands.Create;

internal class CreateUserTemplateCommandHandler(
    IDatabaseContext databaseContext,
    IDatabaseErrorMessagesProvider databaseErrorMessagesProvider)
    : IRequestHandler<CreateUserTemplateCommand, Result<CreateUserTemplateDto, Error>>
{
    public async Task<Result<CreateUserTemplateDto, Error>> Handle(
        CreateUserTemplateCommand request,
        CancellationToken cancellationToken)
    {
        var userTemplate = new UserTemplate { Id = Guid.NewGuid(), Name = request.Name };

        databaseContext.UserTemplates.Add(userTemplate);

        try
        {
            await databaseContext.SaveChangesAsync(cancellationToken);
        }
        catch (Exception exception)
        {
            if (exception.InnerException != null &&
                exception.InnerException.Message.Contains(databaseErrorMessagesProvider.UserTemplateNameUniquenessViolation))
            {
                return Errors.UserTemplate.NameAlreadyExists();
            }

            throw;
        }

        return new CreateUserTemplateDto(userTemplate.Id);
    }
}
