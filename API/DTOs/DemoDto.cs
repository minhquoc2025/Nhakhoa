namespace API.DTOs
{
    public class DemoDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public class DemoFilter
    {
        public string Keyword { get; set; }
    }
}