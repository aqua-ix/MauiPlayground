namespace MauiPlayground.ViewModels;

public class ThirdPageViewModel : BaseViewModel
{
    private ISemanticScreenReader _screenReader { get; }
    private INavigationService _navigationService { get; }
    private int _count;

    public ThirdPageViewModel(ISemanticScreenReader screenReader, INavigationService navigationService)
    {
        _screenReader = screenReader;
        _navigationService = navigationService;
        NavigateToMainPage = new DelegateCommand(OnCommandExecuted);
    }

    public string Title => "Third Page";

    private string _text = "Go back to Main Page";

    public string Text
    {
        get => _text;
        set => SetProperty(ref _text, value);
    }

    public DelegateCommand NavigateToMainPage { get; }

    private void OnCommandExecuted()
    {
        Console.WriteLine("[ThirdPage] OnCommandExecuted()");
        IsNavigateButtonPressed = true;
        _navigationService.NavigateAsync("/NavigationPage/MainPage");
    }
}