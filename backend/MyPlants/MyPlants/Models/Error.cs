namespace MyPlants.Models
{
    public class Error
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public List<Error> Errors { get; set; }
    }
}
