namespace Razor.Model;

public class Shedule
{
    public required int Id { get; set; }
    public required DateTime StartFilm { get; set; }
    public required DateTime EndFilm { get; set; }
    public required Movie Movie { get; set; }
    public required HallCinema HallCinema { get; set; }
}