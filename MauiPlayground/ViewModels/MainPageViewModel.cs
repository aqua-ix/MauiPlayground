namespace MauiPlayground.ViewModels;

public class MainPageViewModel : BaseViewModel
{
    private ISemanticScreenReader _screenReader { get; }
    private INavigationService _navigationService { get; }
    private int _count;

    public MainPageViewModel(ISemanticScreenReader screenReader, INavigationService navigationService)
    {
        _screenReader = screenReader;
        _navigationService = navigationService;
        NavigateToNextPage = new DelegateCommand(OnCommandExecuted);
    }

    public string Title => "Main Page";

    private string _text = "Go to Second Page";

    public string Text
    {
        get => _text;
        set => SetProperty(ref _text, value);
    }

    public DelegateCommand NavigateToNextPage { get; }

    private void OnCommandExecuted()
    {
        Console.WriteLine("[MainPage] OnCommandExecuted()");
        IsNavigateButtonPressed = true;
        _navigationService.NavigateAsync("SecondPage");
    }
}