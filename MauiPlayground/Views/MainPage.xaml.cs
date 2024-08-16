using MauiPlayground.ViewModels;

namespace MauiPlayground.Views
{
    public partial class MainPage : ContentPage, INavigateUpHandler
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            Console.WriteLine("[MainPage] OnBackButtonPressed()");
            return false;
        }

        public void OnNavigateUpButtonPressed()
        {
            Console.WriteLine("[MainPage] OnNavigateUpButtonPressed()");
            if (BindingContext is BaseViewModel viewModel)
            {
                viewModel.IsNavigateUpButtonPressed = true;
            }
        }
    }
}