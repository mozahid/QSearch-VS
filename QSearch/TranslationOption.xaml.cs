namespace QSearch;
        
public partial class TranslationOption
{
    public TranslationOption(string source)
    {
        var english = new ImageButton { Source = "us.png", Aspect= Aspect.Fill, BackgroundColor = Colors.GhostWhite, HeightRequest = 30, WidthRequest = 100, HorizontalOptions= LayoutOptions.Center, VerticalOptions= LayoutOptions.Center, Shadow = new Shadow { Opacity = 0.5f, Offset = new Point(5, 5), Radius = 10 } };
        english.Clicked += OnEnglishButtonClicked;
 
        var urdu = new ImageButton { Source = "pk.png", Aspect= Aspect.Fill, BackgroundColor = Colors.GhostWhite, HeightRequest = 30, WidthRequest = 100, HorizontalOptions= LayoutOptions.Center, VerticalOptions= LayoutOptions.Center, Shadow = new Shadow { Opacity = 0.5f, Offset = new Point(5, 5), Radius = 10 } };
        urdu.Clicked += OnUrduButtonClicked;

        switch(source)
        {
            case "SURAH":
            case "PARA":
            case "GOTO":
                    var no_translation = new ImageButton { Source = "no_translation.png", Aspect= Aspect.Fill, BackgroundColor = Colors.GhostWhite, HeightRequest = 30, WidthRequest = 100, HorizontalOptions= LayoutOptions.Center, VerticalOptions= LayoutOptions.Center, Shadow = new Shadow { Opacity = 0.5f, Offset = new Point(5, 5), Radius = 10 } };
                    no_translation.Clicked += OnNoTranslationClicked;
                    Content = new VerticalStackLayout
                    {
                        Children = 
                        {
                            new Label { Text = "Choose a language" },
                            
                            english,
                            urdu,
                            no_translation
                        },
                        Spacing = 6
                    };
                    break;
            default:
                    Content = new VerticalStackLayout
                    {
                        Children = 
                        {
                            new Label { Text = "Choose a language" },
                            
                            english,
                            urdu
                        },
                        Spacing = 6
                    };            
            break;
        }
    }
#nullable enable
    async void OnEnglishButtonClicked(object? sender, EventArgs e)
    {
        await CloseAsync(1);
    }
    
    async void OnUrduButtonClicked(object? sender, EventArgs e)
    {

        await CloseAsync(2);
    }

    async void OnNoTranslationClicked(object? sender, EventArgs e)
    {

        await CloseAsync(3);
    }
#nullable disable
}