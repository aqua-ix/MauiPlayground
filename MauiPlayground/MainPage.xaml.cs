﻿namespace MauiPlayground
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SecondPage());
        }

        protected override bool OnBackButtonPressed()
        {
            Console.WriteLine("[MainPage] OnBackButtonPressed()");
            return false;
        }
    }

}
