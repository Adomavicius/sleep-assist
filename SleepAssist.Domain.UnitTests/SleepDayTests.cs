using AutoFixture.NUnit3;
using FluentAssertions;
using SleepAssist.Domain.UnitTests.Customizations;
using SleepAssist.Domain.ValueObjects;

namespace SleepAssist.Domain.UnitTests
{
    public class SleepDayTests
    {
        [Test, AutoData]
        public void SleepDay_ReturnsCorrect_TotalAwake([SleepDay] SleepDay sleepDay)
        {
            var totalAwake = sleepDay.SleepLogItems.Sum(x => x.TotalAwake);

            sleepDay.TotalAwake.Should().Be(totalAwake);
        }

        [Test, AutoData]
        public void SleepDay_ReturnsCorrect_TotalAsleep([SleepDay] SleepDay sleepDay)
        {
            var totalAsleep = sleepDay.SleepLogItems.Sum(x => x.TotalAsleep);

            sleepDay.TotalAsleep.Should().Be(totalAsleep);
        }
    }
}