using System.ComponentModel.DataAnnotations;

namespace Razor.Model;

public class HallCinema
{
    [Key]
    public required int NumberHall { get; set; }
    public required int CountRows { get; set; }
    public required int CountSeatc { get; set; }
}