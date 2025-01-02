namespace MyPlants.CustomExceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message = "Entity was not found") : base(message) { }
    }
}
