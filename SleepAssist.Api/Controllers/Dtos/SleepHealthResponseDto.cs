namespace SleepAssist.Api.Controllers.Dtos;

public class SleepHealthResponseDto
{
    public TimeSpan SleepDebt { get; set; }
    public decimal Efficiency { get; set; }
    public int TotalDays { get; set; }
}