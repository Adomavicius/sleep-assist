using Microsoft.AspNetCore.Mvc;
using SleepAssist.Api.Controllers.Dtos;
using SleepAssist.Domain.Entities;
using SleepAssist.Domain.ValueObjects;

namespace SleepAssist.Api.Controllers
{
    [Route("api/[controller]")]
    public class SleepController : Controller
    {
        [HttpPost("health")]
        public SleepHealthResponseDto Health([FromBody] SleepHealthRequestDto request)
        {
            var sleepRange = new SleepRangeEntity();

            foreach (var sleepDto in request.Sleep)
            {
                var sleepDay = new SleepDay
                {
                    // TODO: resolve DateOnly properly from request
                    Date = new DateOnly(sleepDto.DateOfSleep.Year, sleepDto.DateOfSleep.Month, sleepDto.DateOfSleep.Day),
                    SleepLogItems =
                    [
                        new SleepLog
                        {
                            EndTime = sleepDto.EndTime,
                            StartTime = sleepDto.StartTime,
                            TotalAsleep = new Minutes(sleepDto.MinutesAsleep),
                            TotalAwake = new Minutes(sleepDto.MinutesAwake)
                        }
                    ]
                };

                sleepRange.AddSleepDay(sleepDay);
            }

            var debt = sleepRange.GetSleepDebt(new Minutes(7 * 60 + 30));

            return new SleepHealthResponseDto
            {
                SleepDebt = TimeSpan.FromMinutes(debt),
                Efficiency = sleepRange.GetSleepEfficiency(),
                TotalDays = sleepRange.SleepDays.Count
            };
        }
    }
}
