using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace PW_Lab2;

public partial class KomputerWindow : Window {
    
    public decimal SelectedPrice { get; private set; }
    public KomputerWindow(decimal komputerCena) {
        InitializeComponent();
    }
    
    private void OkClicked(object? sender, RoutedEventArgs e)
    {
        decimal cpuPrice = CpuComboBox.SelectedIndex switch
        {
            0 => 800,
            1 => 700,
            _ => 0
        };

        decimal diskPrice = 0;
        if (Dysk1.IsChecked == true) diskPrice += 200;
        if (Dysk2.IsChecked == true) diskPrice += 300;
        if (Dysk3.IsChecked == true) diskPrice += 400;

        SelectedPrice = cpuPrice + diskPrice + 1000;
        Close(true);
    }

    private void CancelClicked(object? sender, RoutedEventArgs e)
    {
        Close(false);
    }
}