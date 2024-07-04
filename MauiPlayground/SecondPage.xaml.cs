namespace MauiPlayground
{
    public partial class SecondPage : ContentPage
    {
        public SecondPage()
        {
            InitializeComponent();
        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        protected override bool OnBackButtonPressed()
        {
            Console.WriteLine("[SecondPage] OnBackButtonPressed()");
            return false;
        }
    }

}
