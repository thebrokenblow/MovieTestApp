namespace MovieLibrary;

public class Movie
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public required string URL { get; set; }
    public required string Description { get; set; }
    public required double Cost { get; set; }
}