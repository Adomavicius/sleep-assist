namespace SleepAssist.Domain.ValueObjects;

public record struct Percentage(decimal Percent)
{
    public decimal Percent { get; } = Percent;

    public static implicit operator decimal(Percentage d) => d.Percent;
    public static explicit operator Percentage(decimal b) => new(b);

    public override string ToString()
    {
        return $"{Percent:P}";
    }

    public Percentage GetRounded(int precision)
    {
        return new Percentage(Math.Round(Percent, precision));
    }
}