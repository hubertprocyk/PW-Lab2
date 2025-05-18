using System.Diagnostics;
using System.Globalization;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace PW_Lab2;

public partial class MonitorWindow : Window {
    
    public decimal SelectedPrice { get; private set; }
    public MonitorWindow(decimal monitorCena) {
        InitializeComponent();
        MonitorList.SelectionChanged += (s, e) =>
        {
            decimal sum = 0;
            Debug.Assert(MonitorList.SelectedItems != null, "MonitorList.SelectedItems != null");
            foreach (ListBoxItem item in MonitorList.SelectedItems)
            {
                var content = item.Content?.ToString();
                var priceText = content?.Split("-")[1].Trim().Replace("zł", "").Trim();
                if (decimal.TryParse(priceText, out var price))
                    sum += price;
            }
            MonitorPrice.Text = sum.ToString(CultureInfo.CurrentCulture);
        };
    }
    
    private void OkClicked(object? sender, RoutedEventArgs e)
    {
        if (decimal.TryParse(MonitorPrice.Text, out var price))
        {
            SelectedPrice = price;
        }
        Close(true);
    }

    private void CancelClicked(object? sender, RoutedEventArgs e)
    {
        Close(false);
    }
}