using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Windows.Foundation;

namespace QSearch.Platforms.Windows;

public sealed class ArabicTextLayout : global::QSearch.IArabicTextLayout
{
    public global::QSearch.ArabicLayoutResult Measure(
        string text,
        double width,
        double fontSize,
        string? fontFamily = null)
    {
        if (string.IsNullOrWhiteSpace(text) || width <= 0 || fontSize <= 0)
            return new ArabicLayoutResult();

        const double lineSpacing = 1.8f;
        var lineHeight = fontSize * lineSpacing;

        var textBlock = new TextBlock
        {
            Text = text,
            TextWrapping = TextWrapping.Wrap,
            FlowDirection = Microsoft.UI.Xaml.FlowDirection.RightToLeft,
            TextAlignment = Microsoft.UI.Xaml.TextAlignment.Right,
            FontSize = fontSize,
            LineHeight = lineHeight,
            LineStackingStrategy = LineStackingStrategy.BlockLineHeight
        };

        if (!string.IsNullOrWhiteSpace(fontFamily))
        {
            // WinUI requires the native family name, not the MAUI registration
            // alias or the packaged .ttf filename.
            var nativeFamily = global::QSearch.FontFamilyNameResolver.ToPostScriptName(fontFamily);
            textBlock.FontFamily = new FontFamily(nativeFamily);
        }

        textBlock.Measure(new global::Windows.Foundation.Size(width, double.PositiveInfinity));
        var measuredHeight = textBlock.DesiredSize.Height;

        if (measuredHeight <= 0)
            return new ArabicLayoutResult();

        var lineCount = Math.Max(1, (int)Math.Round(measuredHeight / lineHeight));

        return new global::QSearch.ArabicLayoutResult
        {
            LineCount = lineCount,
            LineHeight = lineHeight,
            RowSpacing = 4
        };
    }
}
