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
        public static Error NotFoundDonorError = new("Donor.NotFound", "The donor informed was not found.");
        public static Error NotAllowedAgeError = new("Donor.NotAllowedAgeError", "The age informed is invalid.");
        public static Error NotAllowedWeightError =
            new("Donor.NotAllowedWeightError", "The weight informed is invalid."); 
        public static Error EmailNotUniqueError =
            new ("Donor.EmailNotUniqueError", "The email informed is already taken.");
        public static Error NotInValidIntervalError = new("Donor.NotInValidIntervalError",
            "The donor informed is not within a valid interval to donate.");
    }

    public static class Donation
    {
        public static Error NotValidQuantityError =
            new("Donation.NotValidQuantityError", "The donation has an invalid blood quantity.");
    }

    public static class Stock
    {
        public static Error NotFoundStockError = new("Stock.NotFound", "The stock informed was not found.");
        public static Error DuplicatedStockError = new("Stock.DuplicatedStockError",
            "There's already an stock of this blood type and RH factor.");
    }
}