using System;

namespace QSearch;

using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.Platform;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class VerseTextDrawable : IDrawable
{
    private readonly VerseTextView _control;
    private readonly IArabicTextLayout? _arabicTextLayout;  
    private readonly IFontRegistrar? _fontRegistrar;
    private readonly IImage? _verseImage;

    private readonly IImage? _rukuImage;
    private readonly IImage? _sujudImage;

    public VerseTextDrawable(
        VerseTextView control,
        IArabicTextLayout? arabicTextLayout,
        IFontRegistrar? fontRegistrar = null)
    {
        _control = control;
        _arabicTextLayout = arabicTextLayout;
        _fontRegistrar = fontRegistrar;
        _verseImage = TryLoadImage(_control.VerseImage);
        _rukuImage = TryLoadImage("ruku.svg");
        _sujudImage = TryLoadImage("sujud.svg");
    }

    public VerseTextDrawable(VerseTextView control)
    {
        _control = control;
        _verseImage = TryLoadImage(_control.VerseImage);
    }

    private static IImage? TryLoadImage(string? filename)
    {
        if (string.IsNullOrWhiteSpace(filename))
            return null;

        var candidate = filename;
        if (candidate.EndsWith(".svg", StringComparison.OrdinalIgnoreCase))
        {
            candidate = Path.ChangeExtension(candidate, ".png");
        }

        try
        {
            using var stream = FileSystem.OpenAppPackageFileAsync(candidate)
                .GetAwaiter()
                .GetResult();

            if (stream is null)
                return null;

            return PlatformImage.FromStream(stream);
        }
        catch
        {
            return null;
        }
    }
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        if (string.IsNullOrWhiteSpace(_control.VerseText))
            return;

        float width = dirtyRect.Width;

        if (width <= 0)
            return;

        float fontSize = _control.FontSize;
        var font = CreateFont();
        canvas.Font = font;
        canvas.FontSize = fontSize;
        var result = _arabicTextLayout?.Measure(
            _control.VerseText,
            width,
            _control.FontSize,
            _control.FontName);

        float lineHeight = result?.LineHeight > 0
            ? Convert.ToSingle(result.LineHeight)
            : fontSize * 1.8f;
///line height adjustment for different fonts
        float lh = lineHeight;
        switch(_control.FontName)
        {
            case "Qalam":
#if ANDROID 
                    lh += 2;
#else
                    lh += 1;
#endif
                    break;
            case "MeQuran":
                    lh += 4;
                    break;
            case "Uthmani":
                    lh += 2;
                    break;
        }     

        canvas.Font = font;
        canvas.FontSize = fontSize;
        canvas.FontColor = _control.TextColor;
        int lineCount = 0;
        string lastLine = "";
        float lastLineX = width;
        float currentY = 0;
        canvas.DrawWrappedArabicString(
            _control.VerseText,
            0,
            0,
            width,
            lh,
            font,
            fontSize,
            ref lineCount,
            ref lastLine,
            ref lastLineX,
            ref currentY);
//// verse graphics adjustment using rowspacing parameter
        if (result is not null)
        {
#if IOS || MACCATALYST || WINDOWS
            switch (_control.FontName)
            {
                case "Qalam":
                    currentY = (lineCount > 1) ? currentY - lh / 4 : currentY - 8;
                    break;
                case "MeQuran":
                    currentY = (lineCount > 1) ? currentY - lh / 6 : currentY - 8;
                    break;
                case "IndoPak":
                    currentY = (lineCount > 1) ? currentY - lh / 4 : currentY - 12;
                    break;
                case "Lateef":
                    currentY = (lineCount > 1) ? currentY - lh / 3 : currentY - 12;
                    break;
                case "Uthmani":
                    currentY = (lineCount > 1) ? currentY - lh / 4 : currentY - 8;
                    break;
            }            
#elif ANDROID
            switch(_control.FontName)
            {
                case "Lateef":
                    currentY = currentY - 8;
                    break;
            }
#endif
            DrawLastLine(
                canvas,
                lastLine,
                width,
                lastLineX, 
                currentY,
                lineCount,
                lineHeight);
        }
    }
    private void DrawLastLine(
        ICanvas canvas,
        string text,
        float width,
        float x,
        float y,
        int lineCount = 1,
        float lineHeight = 0)
    {
        var font = CreateFont();
        var textSize = canvas.GetStringSize(
            text,
            font,
            Convert.ToInt32(_control.FontSize));
        float badgeX = Math.Max(0, x);
        float badgeY = y + lineHeight / 2;
        // next line
        if (badgeX <= 10) 
        {
            badgeY += lineHeight;
            badgeX = width - 35;
        }
        else if (badgeX > 24) badgeX -= 24;
        if (_verseImage is not null)
        {
            canvas.DrawImage(
                _verseImage,
                badgeX,
                badgeY,
                34,
                34);
        }
        else
        {
            DrawVerseGraphic(
                canvas,
                badgeX,
                badgeY,
                lineHeight / 2);
        }

        canvas.Font = new Microsoft.Maui.Graphics.Font("Tahoma", Convert.ToInt32(18));
        canvas.FontSize = Convert.ToInt32(18) * 0.65f;
        canvas.FontColor = _control.TextColor;

        canvas.DrawString(
            Convert.ToString(_control.VerseNumber),
            badgeX,
            badgeY,
            34,
            34,
            HorizontalAlignment.Center,
            VerticalAlignment.Center);

        /// if ruku or sujood is true, draw the respective image
        if (_control.Ruku && _rukuImage is not null)
        {
            badgeX -= 40;
            if (badgeX <= 10) 
            {
                badgeY += lineHeight;
                badgeX = width - 35;
            }
            else if (badgeX > 24) badgeX -= 24;
            canvas.SaveState();

            canvas.DrawImage(
                _rukuImage,
                badgeX,
                badgeY,
                34,
                34);
            canvas.RestoreState();
        }
        if (_control.Sujood && _sujudImage is not null)
        {
            badgeX -= 40;
            if (badgeX <= 10) 
            {
                badgeY += lineHeight;
                badgeX = width - 35;
            }
            else if (badgeX > 24) badgeX -= 24;
            canvas.SaveState();

            canvas.DrawImage(
                _sujudImage,
                badgeX,
                badgeY,
                34,
                34);
            canvas.RestoreState();

        }       
    }
    private void DrawVerseGraphic(
        ICanvas canvas,
        float x,
        float y,
        float size)
    {
        // For now use a circle.
        // Replace this with your actual image later.
        canvas.StrokeColor = _control.TextColor;
        canvas.StrokeSize = 1.5f;

        canvas.DrawCircle(
            x + size / 2,
            y + size / 2,
            size / 2 - 1);
    }

    private Microsoft.Maui.Graphics.Font CreateFont()
    {
        var fontName = ResolveFontFamilyName();
        return string.IsNullOrWhiteSpace(fontName)
            ? Microsoft.Maui.Graphics.Font.Default
            : new Microsoft.Maui.Graphics.Font(fontName, FontWeights.Normal);
    }

    private string? ResolveFontFamilyName()
    {
        var requested = _control.FontName?.Trim();
        if (string.IsNullOrWhiteSpace(requested))
            return null;

        var alias = FontFamilyNameResolver.NormalizeAlias(requested);

#if IOS || MACCATALYST || WINDOWS
        return FontFamilyNameResolver.ToPostScriptName(requested);
#else
        return _fontRegistrar?.GetFont(alias)
            ?? _control.ResolveRegisteredFont(alias)
            ?? alias;
#endif
    }
}

internal static class FontFamilyNameResolver
{
    public static string NormalizeAlias(string fontName) => fontName.Trim() switch
    {
        "AlQalam" => "Qalam",
        "Lateef" => "Lateef",
        "Uthmani" => "Uthmani",
        _ => fontName.Trim()
    };

    public static string ToPostScriptName(string fontName) => NormalizeAlias(fontName) switch
    {
#if WINDOWS
        "Qalam" => "Al Majeed Quranic Font",
        "IndoPak" => "AlQuran IndoPak by QuranWBW",
        "MeQuran" => "me_quran",
        "Uthmani" => "KFGQPC HAFS UthmanicScript",
        "hafs" => "KFGQPC HAFS UthmanicScript",
        "Lateef" => "Lateef",
        "NotoArabic" => "Arabic UI Text Medium",
        _ => fontName.Trim()
#else
        "Qalam" => "Al-Majeed-Quranic-Font",
        "IndoPak" => "AlQuranIndoPakbyQuranWBW",
        "MeQuran" => "me_quran",
        "Uthmani" => "KFGQPCHAFSUthmanicScript-Regula",
        "hafs" => "KFGQPCHAFSUthmanicScript-Regula",
        "Lateef" => "Lateef-Bold",
         "NotoArabic" => "ArabicUIText-Medium",
        _ => fontName.Trim()
#endif
    };
}

public static class CanvasRtlExtensions
{
    public static void DrawWrappedArabicString(
        this ICanvas canvas, 
        string text, 
        float x, 
        float y, 
        float width, 
        float lineHeight, 
        Microsoft.Maui.Graphics.Font font,
        float fontSize,
        ref int lineCount,
        ref string lastLine,
        ref float lastLineX,
        ref float lineY)
    {
        canvas.FontSize = fontSize;
        
        string[] words = text.Split(' ');
        List<string> lines = new List<string>();
        string currentLine = "";
        // Reconstruct the text block line by line based on constraints
        foreach (var word in words)
        {
            string testLine = string.IsNullOrEmpty(currentLine) ? word : $"{currentLine} {word}";
            var stringSize = canvas.GetStringSize(testLine, font, fontSize);

            if (stringSize.Width > width)
            {
                // Current line is full, save it and start the next
                if (!string.IsNullOrEmpty(currentLine))
                    lines.Add(currentLine);
                
                currentLine = word;
            }
            else
            {
                currentLine = testLine;
            }
        }
        
        if (!string.IsNullOrEmpty(currentLine))
            lines.Add(currentLine);

        // Draw each single line independently to force HorizontalAlignment.Right
        float currentY = y;
        int counter = 0;
        float sz;
        foreach (var line in lines)
        {
#if ANDROID
            sz = canvas.GetStringSize(line, font, fontSize).Width;
            canvas.DrawString(
                line, 
                width - sz,
                currentY, 
                width, 
                lineHeight, 
                HorizontalAlignment.Right, 
                VerticalAlignment.Top
            );
#elif IOS || MACCATALYST
            canvas.DrawString(
                line, 
                0,
                currentY, 
                width, 
                lineHeight, 
                HorizontalAlignment.Right, 
                VerticalAlignment.Top
            );
#elif WINDOWS
            // Force an RTL paragraph for Win2D. ICanvas.DrawString has no direction
            // argument, so Arabic can otherwise be laid out as an LTR paragraph.
            // The exact-width rectangle keeps the visual right edge at `width`.
            sz = canvas.GetStringSize(line, font, fontSize).Width;
            canvas.DrawString(
                "\u202B" + line + "\u202C",
                width - sz,
                currentY,
                sz,
                lineHeight,
                HorizontalAlignment.Left,
                VerticalAlignment.Top
            );
#else
            sz = canvas.GetStringSize(line, font, fontSize).Width;
            canvas.DrawString(
                line,
                width - sz,
                currentY,
                width,
                lineHeight,
                HorizontalAlignment.Right,
                VerticalAlignment.Top
            );
#endif
            // Move the cursor down to the next row
            currentY += lineHeight + 4; 
            counter++;
        }
        lineCount = lines.Count;
        lastLine = lines[lines.Count - 1];
        sz = canvas.GetStringSize(lastLine, font, fontSize).Width;
        lastLineX = width - sz - 25;
        /// adjust last line Y position based on line count and line height
        lineY = currentY - lineHeight - 4;
    }
}