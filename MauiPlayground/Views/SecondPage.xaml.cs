using MauiPlayground.ViewModels;

namespace MauiPlayground.Views;

public partial class SecondPage : ContentPage, INavigateUpHandler
{
    public SecondPage()
    {
        InitializeComponent();
    }

    protected override bool OnBackButtonPressed()
    {
        Console.WriteLine("[SecondPage] OnBackButtonPressed()");
        return false;
    }

    public void OnNavigateUpButtonPressed()
    {
        Console.WriteLine("[SecondPage] OnNavigateUpButtonPressed()");
        if (BindingContext is BaseViewModel viewModel)
        {
            viewModel.IsNavigateUpButtonPressed = true;
        }
    }
}