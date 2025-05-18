using Avalonia.Controls;
using Avalonia.Interactivity;

namespace PW_Lab2;

public partial class MainWindow : Window {
    
    private decimal _komputerCena;
    private decimal _monitorCena;
    public MainWindow() {
        InitializeComponent();
        UpdateTotal();
    }
    
    private async void OpenKomputer(object? sender, RoutedEventArgs e)
    {
        var dialog = new KomputerWindow(_komputerCena);
        var result = await dialog.ShowDialog<bool>(this);
        if (!result) return;
        _komputerCena = dialog.SelectedPrice;
        UpdateTotal();
    }

    private async void OpenMonitor(object? sender, RoutedEventArgs e)
    {
        var dialog = new MonitorWindow(_monitorCena);
        var result = await dialog.ShowDialog<bool>(this);
        if (!result) return;
        _monitorCena = dialog.SelectedPrice;
        UpdateTotal();
    }

    private void UpdateTotal()
    {
        TotalPriceText.Text = $"{_komputerCena + _monitorCena} zł";
    }
}