namespace MauiPlayground.ViewModels;

public class MainPageViewModel : BindableBase
{
    private ISemanticScreenReader _screenReader { get; }
    private INavigationService _navigationService { get; }
    private int _count;

    public MainPageViewModel(ISemanticScreenReader screenReader, INavigationService navigationService)
    {
        _screenReader = screenReader;
        _navigationService = navigationService;
        NavigateToNextPage = new DelegateCommand(OnCommandExecuted);
        CloseApp = new DelegateCommand(OnCloseAppCommandExecuted);
    }

    public string Title => "Main Page";

    private string _text = "Go to Second Page";
    public string Text
    {
        get => _text;
        set => SetProperty(ref _text, value);
    }
    
    private string _closeAppText = "Close App";
    public string CloseAppText
    {
        get => _closeAppText;
        set => SetProperty(ref _closeAppText, value);
    }

    public DelegateCommand NavigateToNextPage { get; }

    private void OnCommandExecuted()
    {
        Console.WriteLine("[MainPage] OnCommandExecuted()");
        _navigationService.NavigateAsync("SecondPage");
    }

    public DelegateCommand CloseApp { get; }

    private void OnCloseAppCommandExecuted()
    {
        Console.WriteLine("[MainPage] CloseApp()");
#if ANDROID
        Platform.CurrentActivity?.Finish();
#endif
    }
}
