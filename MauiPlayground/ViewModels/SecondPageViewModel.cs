namespace MauiPlayground.ViewModels;

public class SecondPageViewModel : BaseViewModel
{
    private ISemanticScreenReader _screenReader { get; }
    private INavigationService _navigationService { get; }
    private int _count;

    public SecondPageViewModel(ISemanticScreenReader screenReader, INavigationService navigationService)
    {
        _screenReader = screenReader;
        _navigationService = navigationService;
        NavigateToNextPage = new DelegateCommand(OnCommandExecuted);
    }

    public string Title => "Second Page";

    private string _text = "Go to Third Page";
    public string Text
    {
        get => _text;
        set => SetProperty(ref _text, value);
    }

    public DelegateCommand NavigateToNextPage { get; }

    private void OnCommandExecuted()
    {
        Console.WriteLine("[SecondPage] OnCommandExecuted()");
        IsNavigateButtonPressed = true;
        _navigationService.NavigateAsync("ThirdPage");
    }
}
