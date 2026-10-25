using System;

namespace QSearch;

public interface IArabicTextLayout
{
    ArabicLayoutResult Measure(
        string text,
        double width,
        double fontSize,
        string? fontFamily = null);
}

public sealed class ArabicLayoutResult
{
    public int LineCount { get; init; }
    // public string LastLine { get; init; } = string.Empty;
    // public double LastLineWidth { get; init; }
    // public double LastLineX { get; init; }
    // public double LastLineY { get; init; }
    // public double LastLineRight { get; init; }
    // public double LastLineBottom { get; init; }
    public double LineHeight { get; init; }
    public double RowSpacing { get; init; } = 4;
}
