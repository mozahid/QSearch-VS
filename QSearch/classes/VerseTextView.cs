using System;
using Microsoft.Maui.Controls.Shapes;

namespace QSearch;

using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;

public class VerseTextView : GraphicsView
{
    private IArabicTextLayout? _arabicTextLayout;
    private IFontRegistrar? _fontRegistrar;
    private double _drawnContentWidth = double.NaN;
    private double _drawnContentHeight;
        public static readonly BindableProperty VerseTextProperty =
        BindableProperty.Create(
            nameof(VerseText),
            typeof(string),
            typeof(VerseTextView),
            string.Empty,
            propertyChanged: OnTextChanged);

    public static readonly BindableProperty VerseNumberProperty =
        BindableProperty.Create(
            nameof(VerseNumber),
            typeof(int),
            typeof(VerseTextView),
            0,
            propertyChanged: OnTextChanged);

    public static readonly BindableProperty FontSizeProperty =
        BindableProperty.Create(
            nameof(FontSize),
            typeof(float),
            typeof(VerseTextView),
            24f,
            propertyChanged: OnTextChanged);

    public static readonly BindableProperty FontNameProperty =
        BindableProperty.Create(
            nameof(FontName),
            typeof(string),
            typeof(VerseTextView),
            null,
            propertyChanged: OnTextChanged);

    public static readonly BindableProperty TextColorProperty =
        BindableProperty.Create(
            nameof(TextColor),
            typeof(Color),
            typeof(VerseTextView),
            Colors.Black,
            propertyChanged: OnTextChanged);

    public static readonly BindableProperty VerseImageProperty =
        BindableProperty.Create(
            nameof(VerseImage),
            typeof(string),
            typeof(VerseTextView),
            null,
            propertyChanged: OnTextChanged);

    public static readonly BindableProperty RukuProperty =
        BindableProperty.Create(
            nameof(Ruku),
            typeof(bool),
            typeof(VerseTextView),
            false,
            propertyChanged: OnTextChanged);

    public static readonly BindableProperty SujoodProperty =
        BindableProperty.Create(
            nameof(Sujood),
            typeof(bool),
            typeof(VerseTextView),
            false,
            propertyChanged: OnTextChanged);

    public string VerseText
    {
        get => (string)GetValue(VerseTextProperty);
        set => SetValue(VerseTextProperty, value);
    }

    public int VerseNumber
    {
        get => (int)GetValue(VerseNumberProperty);
        set => SetValue(VerseNumberProperty, value);
    }

    public float FontSize
    {
        get => (float)GetValue(FontSizeProperty);
        set => SetValue(FontSizeProperty, value);
    }

    public string? FontName
    {
        get => (string?)GetValue(FontNameProperty);
        set => SetValue(FontNameProperty, value);
    }

    public Color TextColor
    {
        get => (Color)GetValue(TextColorProperty);
        set => SetValue(TextColorProperty, value);
    }

    public string VerseImage
    {
        get => (string)GetValue(VerseImageProperty);
        set => SetValue(VerseImageProperty, value);
    }

    public bool Ruku
    {
        get => (bool)GetValue(RukuProperty);
        set => SetValue(RukuProperty, value);
    }

    public bool Sujood
    {
        get => (bool)GetValue(SujoodProperty);
        set => SetValue(SujoodProperty, value);
    }

    public VerseTextView()
    {
        SetDrawable();

        HorizontalOptions = LayoutOptions.Fill;
        VerticalOptions = LayoutOptions.Start;
#if WINDOWS
        // The drawable supplies the RTL paragraph direction. Keeping the WinUI
        // host LTR prevents Windows from mirroring the GraphicsView surface.
        FlowDirection = FlowDirection.LeftToRight;
#else
        FlowDirection = FlowDirection.RightToLeft;
#endif
    }



    protected override void OnHandlerChanged()
    {
        base.OnHandlerChanged();

#if WINDOWS
        // Do not let WinUI mirror the custom drawing surface. The Windows
        // drawable applies RTL text direction and right alignment itself.
        FlowDirection = FlowDirection.LeftToRight;
#endif
        _arabicTextLayout = Handler?.MauiContext?.Services.GetService<IArabicTextLayout>();
        _fontRegistrar = Handler?.MauiContext?.Services.GetService<IFontRegistrar>();
 
        _drawnContentWidth = double.NaN;
        _drawnContentHeight = 0;
        SetDrawable();
        InvalidateMeasure();
    }

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);

        SetDrawable();
        Invalidate();
    }

    protected override Size MeasureOverride(
        double widthConstraint,
        double heightConstraint)
    {
        double width = widthConstraint;

        if (double.IsInfinity(width) || width <= 0)
            width = Width;

        if (double.IsInfinity(width) || width <= 0)
            width = 300;

        if (!double.IsNaN(_drawnContentWidth) &&
            Math.Abs(width - _drawnContentWidth) > 0.5)
        {
            _drawnContentWidth = double.NaN;
            _drawnContentHeight = 0;
        }
        double lineHeight = FontSize * 1.8;
        double rowSpacing = 8;
        int lineCount = 1;

        if (_arabicTextLayout is not null && !string.IsNullOrWhiteSpace(VerseText))
        {
            var result = _arabicTextLayout.Measure(
                VerseText,
                width,
                FontSize,
                FontName);

            if (result.LineHeight > 0)
                lineHeight = result.LineHeight;

            rowSpacing = result.RowSpacing;
            lineCount = Math.Max(1, result.LineCount);         
        }
        double height = lineHeight * lineCount;
#if IOS || MACCATALYST || WINDOWS
        height += rowSpacing * Math.Max(0, lineCount + 1);
        // switch(FontName)
        // {
        //     case "Lateef":
        //     case "Qalam":
        //     case "IndoPak":
        //             height += 32;
        //         break;
        //     case "MeQuran":
        //             height += 12;
        //             break;
        //     case "Uthmani":
        //             height += 28;
        //             break;
        // }
#elif ANDROID
        height += rowSpacing * Math.Max(0, lineCount + 2);
        // switch(FontName)
        // {
        //     case "NotoArabic":
        //             height += 16;
        //             break;
        //     case "MeQuran":
        //             height += 12;
        //             break;
        // }   
#endif

        if (!double.IsNaN(_drawnContentWidth) &&
            Math.Abs(width - _drawnContentWidth) <= 0.5)
        {
            height = Math.Max(height, _drawnContentHeight);
        }
        return new Size(width, height);
    }

    private static void OnTextChanged(
        BindableObject bindable,
        object oldValue,
        object newValue)
    {
        var control = (VerseTextView)bindable;
        control._drawnContentWidth = double.NaN;
        control._drawnContentHeight = 0;
        control.SetDrawable();
        control.InvalidateMeasure();
        control.Invalidate();
    }

    private void SetDrawable()
    {
        if (Drawable is VerseTextDrawable previousDrawable)
            previousDrawable.RequiredHeightChanged -= OnRequiredHeightChanged;

        var drawable = new VerseTextDrawable(this, _arabicTextLayout, _fontRegistrar);
        drawable.RequiredHeightChanged += OnRequiredHeightChanged;
        Drawable = new VerseTextDrawable(this, _arabicTextLayout, _fontRegistrar);
    }
    
    /// <summary>
    /// height change event
    /// </summary>
    /// <param name="drawable"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    private void OnRequiredHeightChanged(
        VerseTextDrawable drawable,
        double width,
        double height)
    {
        if (!ReferenceEquals(Drawable, drawable) ||
            width <= 0 ||
            height <= 0)
        {
            return;
        }

        if (!double.IsNaN(_drawnContentWidth) &&
            Math.Abs(width - _drawnContentWidth) <= 0.5 &&
            Math.Abs(height - _drawnContentHeight) <= 0.5)
        {
            return;
        }

        _drawnContentWidth = width;
        _drawnContentHeight = height;
        InvalidateMeasure();
    }
        internal string? ResolveRegisteredFont(string? fontFamily)
    {
        if (string.IsNullOrWhiteSpace(fontFamily))
            return null;

        return _fontRegistrar?.GetFont(fontFamily.Trim()) ?? fontFamily.Trim();
    }
}
