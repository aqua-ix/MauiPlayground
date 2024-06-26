namespace MauiPlayground.Views
{
    public partial class MainPage : ContentPage
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
    }

}
