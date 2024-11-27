using SleepAssist.Domain.ValueObjects;

namespace SleepAssist.Domain.Entities;

public class SleepRangeEntity
{
    public IList<SleepDay> SleepDays { get; } = [];
    private const int SleepEfficiencyPrecision = 4;

    public Minutes TotalAwake => new(SleepDays.Sum(x => x.TotalAwake));

    public Minutes TotalAsleep => new(SleepDays.Sum(x => x.TotalAsleep));

    public Minutes GetSleepDebt(Minutes targetDailyAsleep)
    {
        var totalTargetAsleep = new Minutes(SleepDays.Count * targetDailyAsleep);

        return new Minutes(totalTargetAsleep - TotalAsleep);
    }

    public Percentage GetSleepEfficiency()
    {
        decimal totalTimeInBed = TotalAwake + TotalAsleep;

        return new Percentage(TotalAsleep / totalTimeInBed).GetRounded(SleepEfficiencyPrecision);
    }

    public void AddSleepDay(SleepDay sleepDay)
    {
        var foundSleepDay = SleepDays.FirstOrDefault(x => x.Date == sleepDay.Date);

        if (foundSleepDay == null)
        {
            SleepDays.Add(sleepDay);
        }
        else
        {
            foundSleepDay.SleepLogItems.AddRange(sleepDay.SleepLogItems);
        }
    }
}