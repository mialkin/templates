using CSharpFunctionalExtensions;
using MediatR;
using Skeleton.Domain;
using Skeleton.Infrastructure.Interfaces.Database;

namespace Skeleton.UseCases.Users.Commands.Update;

internal class UpdateUserCommandHandler(IDatabaseContext databaseContext)
    : IRequestHandler<UpdateUserCommand, UnitResult<Error>>
{
    public async Task<UnitResult<Error>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await databaseContext.Users.FindAsync(request.Id, cancellationToken);
        if (user is null)
        {
            return UnitResult.Failure(Errors.General.NotFound());
        }

        user.Username = request.Username;

        await databaseContext.SaveChangesAsync(cancellationToken);

        return UnitResult.Success<Error>();
    }
}
