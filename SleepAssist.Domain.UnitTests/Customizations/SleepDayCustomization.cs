using System.Reflection;
using AutoFixture;
using AutoFixture.NUnit3;

namespace SleepAssist.Domain.UnitTests.Customizations;

public class SleepDayCustomization : ICustomization
{
    public void Customize(IFixture fixture)
    {
        fixture.Customize(new DateOnlyCustomization());
    }
}

public class SleepDayAttribute : CustomizeAttribute
{
    public override ICustomization GetCustomization(ParameterInfo parameter) => new SleepDayCustomization();
}