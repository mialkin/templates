namespace Skeleton.Domain;

public static class Errors
{
    public static class General
    {
        public static Error NotFound(Guid id)
        {
            return new Error(code: "record.not.found", message: $"Record with ID \"{id}\" not found");
        }

        public static Error InternalServerError(string message)
        {
            return new Error("internal.server.error", message);
        }
    }
}
