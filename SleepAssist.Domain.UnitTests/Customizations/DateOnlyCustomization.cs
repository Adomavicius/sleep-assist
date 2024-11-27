using AutoFixture;
using SleepAssist.Domain.UnitTests.Attributes;

namespace SleepAssist.Domain.UnitTests.Customizations;

public class DateOnlyCustomization : ICustomization
{
    public void Customize(IFixture fixture) => fixture.Customize<DateOnly>(composer => composer.FromFactory<DateTime>(DateOnly.FromDateTime));
}

public class DateOnlyAttribute : CustomizeParameterAttribute<DateOnlyCustomization>
{
}