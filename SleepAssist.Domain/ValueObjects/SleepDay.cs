namespace SleepAssist.Domain.ValueObjects;

public class SleepDay
{
    public required DateOnly Date { get; init; }

    public List<SleepLog> SleepLogItems { get; init; } = [];

    public Minutes TotalAsleep => new(SleepLogItems.Sum(x => x.TotalAsleep));

    public Minutes TotalAwake => new(SleepLogItems.Sum(x => x.TotalAwake));
}