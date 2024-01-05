namespace Core.Primitives;

/// <summary>
/// Represents an error object
/// </summary>
public class Error : ValueObject
{
    /// <summary>
    /// Builds an error object with a code and a message
    /// </summary>
    /// <param name="code"></param>
    /// <param name="message"></param>
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

/// <summary>
/// Set of generic errors used in multiples areas in the project
/// </summary>
public static class GenericErrors
{
    public static Error None = new Error(string.Empty, string.Empty);
    public static Error NullValue = new Error("NullValue", string.Empty);
    public static Error NotFound = new Error("Entity.NotFound", "The required entity was not found.");
}

/// <summary>
/// Set of domain errors used mainly in the domain layer
/// </summary>
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
        public static Error NotFoundBloodTypeError =
            new("Stock.NotFoundBloodTypeError", "The blood type specified is not valid.");
        public static Error NotFoundBloodRhFactorError =
            new("Stock.NotFoundBloodRhFactorError", "The blood RH factor specified is not valid.");
        public static Error MinimumStockQuantityReachedError = new("Stock.MinimumStockQuantityReachedError",
            "The future stock quantity will be under the minimum allowed capacity.");
        public static Error NotFoundStockError = new("Stock.NotFound", "The stock informed was not found.");
        public static Error DuplicatedStockError = new("Stock.DuplicatedStockError",
            "There's already an stock of this blood type and RH factor.");
    }
}