namespace MauiPlayground.ViewModels;

public class BaseViewModel: BindableBase, IConfirmNavigation
{
    public bool IsNavigateButtonPressed { get; set; }
    public bool IsNavigateUpButtonPressed { get; set; }
    
    public bool CanNavigate(INavigationParameters parameters)
    {
        return IsNavigateUpButtonPressed || IsNavigateButtonPressed;
    }
}