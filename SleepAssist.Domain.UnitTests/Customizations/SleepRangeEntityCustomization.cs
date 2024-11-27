using AutoFixture.NUnit3;
using AutoFixture;
using System.Reflection;

namespace SleepAssist.Domain.UnitTests.Customizations;

public class SleepRangeEntityCustomization : ICustomization
{
    public void Customize(IFixture fixture)
    {
        fixture.Customize(new DateOnlyCustomization());
    }
}

public class SleepRangeEntityAttribute : CustomizeAttribute
{
    public override ICustomization GetCustomization(ParameterInfo parameter) => new SleepRangeEntityCustomization();
}