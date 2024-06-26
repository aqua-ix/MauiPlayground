using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiPlayground.Views;

public partial class SecondPage : ContentPage
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
}