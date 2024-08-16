using MauiPlayground.ViewModels;

namespace MauiPlayground.Views;

public partial class ThirdPage : ContentPage, INavigateUpHandler
{
    public ThirdPage()
    {
        InitializeComponent();
    }

    protected override bool OnBackButtonPressed()
    {
        Console.WriteLine("[ThirdPage] OnBackButtonPressed()");
        return false;
    }

    public void OnNavigateUpButtonPressed()
    {
        Console.WriteLine("[ThirdPage] OnNavigateUpButtonPressed()");
        if (BindingContext is BaseViewModel viewModel)
        {
            viewModel.IsNavigateUpButtonPressed = true;
        }
    }
}