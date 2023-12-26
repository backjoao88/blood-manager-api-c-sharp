namespace Core.Primitives;

public class Error
{
    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }
    public string Code { get; set; }
    public string Message { get; set; }
}

public static class GenericErrors
{
    public static Error None = new Error(string.Empty, string.Empty);
    public static Error NullValue = new Error("NullValue", string.Empty);
}

public static class DomainErrors
{
    public static class Donor
    {
        public static Error InvalidAge = new Error("Donor.InvalidAge", "The age informed is invalid.");
    }
}