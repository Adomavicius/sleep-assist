using AutoFixture.NUnit3;
using FluentAssertions;
using SleepAssist.Domain.Entities;
using SleepAssist.Domain.UnitTests.Customizations;
using SleepAssist.Domain.ValueObjects;

namespace SleepAssist.Domain.UnitTests
{
    public class SleepRangeEntityTests
    {
        [Test, AutoData]
        public void SleepRange_ReturnsCorrect_TotalAwake([SleepRangeEntity] SleepRangeEntity sleepRange)
        {
            var totalAwake = new Minutes(sleepRange.SleepDays.Sum(x => x.SleepLogItems.Sum(y => y.TotalAwake)));

            sleepRange.TotalAwake.Should().Be(totalAwake);
        }

        [Test, AutoData]
        public void SleepRange_ReturnsCorrect_TotalAsleep([SleepRangeEntity] SleepRangeEntity sleepRange)
        {
            var totalAsleep = new Minutes(sleepRange.SleepDays.Sum(x => x.SleepLogItems.Sum(y => y.TotalAsleep)));

            sleepRange.TotalAsleep.Should().Be(totalAsleep);
        }

        [Test]
        [InlineAutoData(60 * 7 + 30)]
        [InlineAutoData(60 * 6)]
        public void SleepRange_ReturnsCorrect_TotalDebt(int targetAsleep, [SleepRangeEntity] SleepRangeEntity sleepRange)
        {
            var totalTargetAsleep = new Minutes(targetAsleep * sleepRange.SleepDays.Count);
            var totalSleep = sleepRange.TotalAsleep;
            var totalCalculatedSleepDebt = totalTargetAsleep - totalSleep;

            var sleepDebt = sleepRange.GetSleepDebt(new Minutes(targetAsleep));

            sleepDebt.Should().Be(totalCalculatedSleepDebt);
        }

        [Test, AutoData]
        public void SleepRange_ReturnsCorrect_SleepEfficiency([SleepRangeEntity] SleepRangeEntity sleepRange)
        {
            var calculatedSleepEfficiency = new Percentage(sleepRange.TotalAsleep / ((decimal) sleepRange.TotalAwake + sleepRange.TotalAsleep)).GetRounded(4);

            var sleepEfficiency = sleepRange.GetSleepEfficiency();

            sleepEfficiency.Should().Be(calculatedSleepEfficiency);
        }
    }
}