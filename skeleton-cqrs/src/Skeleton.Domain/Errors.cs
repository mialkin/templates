namespace Skeleton.Domain;

public static class Errors
{
    public static class General
    {
        public static Error NotFound()
        {
            return new Error(code: "record.not.found", message: "Record not found");
        }

        public static Error InternalServerError(string message)
        {
            return new Error("internal.server.error", message);
        }
    }

    public static class UserTemplate
    {
        public static Error NameAlreadyExists() =>
            new(code: "userTemplate.name.already.exists", message: "Name already exists");
    }
}
