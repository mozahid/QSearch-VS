using Android.Content;
using Android.Graphics;
using Microsoft.Maui.Platform;

namespace QSearch.Platforms.Android;

public sealed class ArabicTextLayout : global::QSearch.IArabicTextLayout
{
    public global::QSearch.ArabicLayoutResult Measure(
        string text,
        double width,
        double fontSize,
        string? fontFamily = null)
    {
        if (string.IsNullOrWhiteSpace(text))
            return new ArabicLayoutResult();

        var context = global::Android.App.Application.Context;

        using var paint = new global::Android.Text.TextPaint(global::Android.Graphics.PaintFlags.AntiAlias);

        var displayMetrics = context.Resources?.DisplayMetrics;
        var scaledDensity = displayMetrics?.ScaledDensity ?? 1f;
        var density = displayMetrics?.Density ?? 1f;

        paint.TextSize = (float)fontSize * scaledDensity;

        paint.Color = global::Android.Graphics.Color.Black;

        // Use the same font as your MAUI Label when possible.
        if (!string.IsNullOrWhiteSpace(fontFamily))
        {
            var typeface = global::Android.Graphics.Typeface.Create(
                fontFamily,
                global::Android.Graphics.TypefaceStyle.Normal);

            paint.SetTypeface(typeface);
        }

        int widthPx = (int)Math.Ceiling(
            width * density);

        // RTL paragraph
        var layout = new global::Android.Text.StaticLayout(
            new Java.Lang.String(text),
            paint,
            widthPx,
            global::Android.Text.Layout.Alignment.AlignNormal,
            1.0f,
            0f,
            false);

        int lineCount = layout.LineCount;

        if (lineCount == 0)
            return new ArabicLayoutResult();

        int lastLine = lineCount - 1;

        int start = layout.GetLineStart(lastLine);
        int end = layout.GetLineEnd(lastLine);

        string lastLineText = text.Substring(
            start,
            end - start).Trim();

        // float lineLeft = layout.GetLineLeft(lastLine);
        // float lineRight = layout.GetLineRight(lastLine);

        // float lineWidth = layout.GetLineWidth(lastLine);

        float lineTop = layout.GetLineTop(lastLine);
        float lineBottom = layout.GetLineBottom(lastLine);

        return new global::QSearch.ArabicLayoutResult
        {
            LineCount = lineCount,

            // LastLine = lastLineText,

            // LastLineWidth = lineWidth / density,

            // LastLineX = lineLeft / density,

            // LastLineY = lineTop / density,

            // LastLineRight = lineRight / density,

            // LastLineBottom = lineBottom / density,

            LineHeight = (lineBottom - lineTop) / density,
            RowSpacing = 4
        };
    }
}