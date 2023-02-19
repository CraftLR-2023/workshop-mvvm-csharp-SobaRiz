using System;

using Avalonia.Controls;

// using CraftLR.EasySave.ViewModels;
namespace CraftLR.EasySave.Views;

public partial class MainWindowView : Window
{
    public MainWindowView()
    {
        InitializeComponent();
    }

    private void OnItemClicked()
    {
        Console.WriteLine("Hello World 1");
    }
}