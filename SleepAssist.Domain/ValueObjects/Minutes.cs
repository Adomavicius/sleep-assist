namespace SleepAssist.Domain.ValueObjects;

public readonly record struct Minutes(int Duration)
{
    public int Duration { get; } = Duration;

    public static implicit operator int(Minutes d) => d.Duration;
    public static explicit operator Minutes(int b) => new(b);
    public static Minutes operator +(Minutes a, Minutes b) => new(a.Duration + b.Duration);
    public static Minutes operator -(Minutes a, Minutes b) => new(a.Duration - b.Duration);
    public static Minutes operator *(Minutes a, int fraction) => new(a.Duration * fraction);

    public override string ToString()
    {
        return Duration.ToString();
    }
}