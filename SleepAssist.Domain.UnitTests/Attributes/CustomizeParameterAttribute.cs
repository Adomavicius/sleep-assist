using AutoFixture.NUnit3;
using AutoFixture;
using System.Reflection;

namespace SleepAssist.Domain.UnitTests.Attributes;

[AttributeUsage(AttributeTargets.Parameter)]
public class CustomizeParameterAttribute<T> : CustomizeAttribute where T : ICustomization, new()
{
    public override ICustomization GetCustomization(ParameterInfo parameter) => parameter == null ? throw new ArgumentNullException(nameof(parameter)) : (ICustomization)new T();
}