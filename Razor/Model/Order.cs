namespace Razor.Model;

public class Order
{
    public int ResultCost { get; set; }
    public List<Shedule> Shedules { get; set; } = [];
}