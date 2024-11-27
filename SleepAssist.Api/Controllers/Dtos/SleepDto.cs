namespace SleepAssist.Api.Controllers.Dtos;

public class SleepDto
{
    public DateTime DateOfSleep { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int MinutesAsleep { get; set; }
    public int MinutesAwake { get; set; }
}