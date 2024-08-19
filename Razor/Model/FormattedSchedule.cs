namespace Razor.Model;

public class FormattedSchedule
{
    public Dictionary<Movie, List<Schedule>>? SchedulesByMovie { get; set; }
}