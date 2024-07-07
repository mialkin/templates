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

    public static class Word
    {
        public static Error UsernameAlreadyExists() =>
            new(code: "user.username.already.exists", message: "Username already exists");
    }
}
