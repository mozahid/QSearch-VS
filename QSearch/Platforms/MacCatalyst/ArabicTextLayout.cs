using CoreFoundation;
using CoreGraphics;
using CoreText;
using Foundation;
using UIKit;

namespace QSearch.Platforms.MacCatalyst;

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

		var font = CreateFont(fontSize, fontFamily);

		using var attributedString = new NSMutableAttributedString(text);

		attributedString.AddAttribute(
			UIStringAttributeKey.Font,
			font,
			new NSRange(0, text.Length));

		using var paragraphStyle = new NSMutableParagraphStyle();
		paragraphStyle.BaseWritingDirection = NSWritingDirection.RightToLeft;
		paragraphStyle.Alignment = UITextAlignment.Right;

		attributedString.AddAttribute(
			CTStringAttributeKey.ParagraphStyle,
			paragraphStyle,
			new NSRange(0, text.Length));

		using var framesetter = new CTFramesetter(attributedString);

		using var path = new CGPath();
		path.AddRect(new CGRect(0, 0, width, double.MaxValue));

		using var frame = framesetter.GetFrame(new NSRange(0, 0), path, null);

		if (frame is null)
			return new ArabicLayoutResult();

		var lines = frame.GetLines();

		if (lines is null || lines.Length == 0)
			return new ArabicLayoutResult();

		var lastLine = lines[lines.Length - 1];

		var lineWidth = lastLine.GetTypographicBounds(
			out var lineAscent,
			out var lineDescent,
			out var lineLeading);

		var lineRange = lastLine.StringRange;
		int start = (int)lineRange.Location;
		int length = (int)lineRange.Length;

		string lastLineText = text.Substring(start, length).Trim();

		var origins = new CGPoint[lines.Length];
		frame.GetLineOrigins(new NSRange(0, lines.Length), origins);

		var origin = origins[lines.Length - 1];

		double lineHeight = lineAscent + lineDescent + lineLeading;

		return new global::QSearch.ArabicLayoutResult
		{
			LineCount = lines.Length,
			LineHeight = lineHeight,
			RowSpacing = 4
		};
	}

	private static UIFont CreateFont(double fontSize, string? fontFamily)
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
