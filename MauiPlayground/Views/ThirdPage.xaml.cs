using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiPlayground.Views;

public partial class ThirdPage : ContentPage
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
}