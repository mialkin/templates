using CSharpFunctionalExtensions;
using MediatR;

namespace Skeleton.UseCases.UserTemplates.Queries.Get;

public record GetUserTemplateQuery(Guid Id) : IRequest<Maybe<GetUserTemplateDto>>;
