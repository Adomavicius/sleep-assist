namespace SleepAssist.Domain.ValueObjects;

public record SleepLog
{
    public required DateTime StartTime { get; init; }
    public required DateTime EndTime { get; init; }

    public required Minutes TotalAsleep { get; init; }
    public required Minutes TotalAwake { get; init; }
};