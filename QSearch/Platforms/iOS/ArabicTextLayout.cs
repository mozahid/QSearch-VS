using CoreFoundation;
using CoreGraphics;
using CoreText;
using Foundation;
using UIKit;

namespace QSearch.Platforms.iOS;

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

        var font = CreateFont(
            fontSize,
            fontFamily);

        using var attributedString =
            new NSMutableAttributedString(text);

        attributedString.AddAttribute(
            UIStringAttributeKey.Font,
            font,
            new NSRange(0, text.Length));

        // Force RTL paragraph direction.
        using var paragraphStyle =
            new NSMutableParagraphStyle();

        paragraphStyle.BaseWritingDirection =
            NSWritingDirection.RightToLeft;

        paragraphStyle.Alignment =
            UITextAlignment.Right;

        attributedString.AddAttribute(
            CTStringAttributeKey.ParagraphStyle,
            paragraphStyle,
            new NSRange(0, text.Length));

        using var framesetter =
            new CTFramesetter(attributedString);

        using var path = new CGPath();
        path.AddRect(
            new CGRect(
                0,
                0,
                width,
                double.MaxValue));

        using var frame =
            framesetter.GetFrame(
                new NSRange(0, 0),
                path,
                null);

        if (frame is null)
            return new ArabicLayoutResult();

        var lines = frame.GetLines();

        if (lines is null || lines.Length == 0)
            return new ArabicLayoutResult();

        int lastIndex = lines.Length - 1;

        var line = lines[lastIndex];

        nfloat lineAscent;
        nfloat lineDescent;
        nfloat lineLeading;

        nfloat lineWidth =
            (nfloat)line.GetTypographicBounds(
                out lineAscent,
                out lineDescent,
                out lineLeading);

        // Get actual character range of final line.
        // var lineRange = line.StringRange;

        // int start = (int)lineRange.Location;
        // int length = (int)lineRange.Length;

        // string lastLineText =
        //     text.Substring(start, length).Trim();

        // CoreText origin is bottom-left.
        // var origins = new CGPoint[lines.Length];

        // frame.GetLineOrigins(
        //     new NSRange(0, lines.Length),
        //     origins);

        // var origin = origins[lastIndex];

        double lineHeight =
            lineAscent + lineDescent + lineLeading;

        return new global::QSearch.ArabicLayoutResult
        {
            LineCount = lines.Length,

            // LastLine = lastLineText,

            // LastLineWidth = lineWidth,

            // LastLineX = origin.X,

            // LastLineY =
            //     origin.Y - lineDescent,

            // LastLineRight =
            //     origin.X + lineWidth,

            // LastLineBottom =
            //     origin.Y - lineDescent,

            LineHeight = lineHeight,
            RowSpacing = 8
        };
    }

    private static UIFont CreateFont(
        double fontSize,
        string? fontFamily)
    {
        if (!string.IsNullOrWhiteSpace(fontFamily))
        {
            var postScriptName = global::QSearch.FontFamilyNameResolver.ToPostScriptName(fontFamily);
            var customFont = UIFont.FromName(postScriptName, (nfloat)fontSize);
            if (customFont is not null)
                return customFont;
        }

        return UIFont.SystemFontOfSize((nfloat)fontSize);
    }
}

