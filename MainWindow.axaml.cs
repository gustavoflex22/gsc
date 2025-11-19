using Avalonia.Controls;
using Avalonia.Interactivity;
using FuturoDoTrabalho.Models;
using System.Threading.Tasks;

namespace FuturoDoTrabalho
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private PapelTrabalho GetSelectedWorkRole()
        {
            var selected = (WorkModelComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString();

            return selected switch
            {
                "Remoto" => new RemoteWorker(),
                "Híbrido" => new HybridWorker(),
                "Presencial" => new OnsiteWorker(),
                _ => new HybridWorker()
            };
        }

        private async void OnAboutClick(object? sender, RoutedEventArgs e)
        {
            await SimpleMessageBox.Show(this,
                "FutureWork IA\n\n" +
                "Protótipo criado para o Challenge FIAP – O Futuro do Trabalho.\n" +
                "Mostra como IA, bem-estar, inclusão e sustentabilidade podem transformar o trabalho.",
                "Sobre o Projeto");
        }

        private async void OnSimulateClick(object? sender, RoutedEventArgs e)
        {
            var workRole = GetSelectedWorkRole();

            var automation = AutomationSlider.Value;
            var wellbeing = WellbeingSlider.Value;
            var inclusion = InclusionSlider.Value;
            var sustainability = SustainabilitySlider.Value;

            var simulator = new FutureWorkSimulator(workRole);

            var index = simulator.CalculateFutureIndex(automation, wellbeing, inclusion, sustainability);
            var classification = simulator.ClassifyIndex(index);
            var recommendations = simulator.GenerateRecommendations(automation, wellbeing, inclusion, sustainability);

            var rw = new ResultsWindow(workRole.Name, index, classification, recommendations);
            await rw.ShowDialog(this);
        }
    }

    public static class SimpleMessageBox
    {
        public static async Task Show(Window owner, string text, string title)
        {
            var okButton = new Button { Content = "OK", Width = 80, HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Right };
            var textBlock = new TextBlock { Text = text, TextWrapping = Avalonia.Media.TextWrapping.Wrap };
            var panel = new StackPanel
            {
                Margin = new Avalonia.Thickness(16),
                Children =
                {
                    textBlock,
                    new StackPanel
                    {
                        Orientation = Avalonia.Layout.Orientation.Horizontal,
                        HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Right,
                        Children = { okButton }
                    }
                }
            };

            var window = new Window
            {
                Title = title,
                Width = 500,
                Height = 260,
                Content = panel
            };

            okButton.Click += (_, __) => window.Close();
            await window.ShowDialog(owner);
        }
    }
}
