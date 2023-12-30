namespace Core.Primitives;

public class Error : ValueObject
{
    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }
    public string Code { get; set; }
    public string Message { get; set; }
    public override IEnumerable<object> Properties()
    {
        yield return Code;
        yield return Message;
    }
}

public static class GenericErrors
{
    public static Error None = new Error(string.Empty, string.Empty);
    public static Error NullValue = new Error("NullValue", string.Empty);
    public static Error NotFound = new Error("Entity.NotFound", "The required entity was not found.");
}

public static class DomainErrors
{
    public static class Donor
    {
        public static Error InvalidAgeError = new Error("Donor.InvalidAgeError", "The age informed is invalid.");
        public static Error EmailNotUniqueError =
            new Error("Donor.EmailNotUniqueError", "The email informed is already taken.");
    }
}