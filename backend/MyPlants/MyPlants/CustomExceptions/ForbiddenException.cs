namespace MyPlants.CustomExceptions
{
    public class ForbiddenException : Exception
    {
        public ForbiddenException(string message = "Forbidden action") : base(message) { }
    }
}
