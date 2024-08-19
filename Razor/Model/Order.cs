namespace Razor.Model;

public class Order
{
    public int ResultCost { get; set; }
    public List<Schedule> Shedules { get; set; } = [];
}