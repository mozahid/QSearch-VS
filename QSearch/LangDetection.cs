using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;



#if ANDROID
    using Android.Content;
    using Android.Views.InputMethods;
#endif
#if IOS
    using UIKit;
#endif
namespace QSearch;

public class LangDetection
{
    private string languageDetected;
    public LangDetection()
    {
#if ANDROID
    var imm = Android.App.Application.Context.GetSystemService(Context.InputMethodService) as InputMethodManager;
    if (imm != null)
    {
        // Get the current subtype (keyboard layout/language)
        var subtype = imm.CurrentInputMethodSubtype;
        if (subtype != null)
        {
    #if ANDROID24_0_OR_GREATER
                languageDetected = subtype.LanguageTag.Substring(0, 2); // Example: "en-US", "fr-FR"
    #else
                languageDetected = subtype.Locale.Substring(0, 2); // Deprecated but works: "en_US"    
    #endif
        }
    }
#endif
#if IOS 
    languageDetected = UITextInputMode.CurrentInputMode?.PrimaryLanguage.Substring(0, 2) ?? "en";
#endif
    }

    public LangDetection(string input)
    {
        if (input.Any(c => c >= 0x0600 && c <= 0x06FF))
        {
            languageDetected = "ar";
             string urduPattern = @"[\u067E\u0686\u0698\u06A9\u06AF\u0679\u0688\u0691\u06D2\u06BA]";
            Regex urduRegex = new Regex(urduPattern);
            if (urduRegex.IsMatch(input))
            {                
                languageDetected = "ur";
            }
        }
        else 
        {
            Regex regex = new Regex(@"[A-Za-z]+");   
            if (regex.IsMatch(input))
            {
                languageDetected = "en";
            }
            else
            {
                languageDetected = "fr";
            }
        }
    }
    public string LanguageDetected
    {
        get { return languageDetected; }
    }
}
