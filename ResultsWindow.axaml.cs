using Avalonia.Controls;
using Avalonia.Interactivity;

namespace FuturoDoTrabalho
{
    public partial class ResultsWindow : Window
    {
        public ResultsWindow()
        {
            InitializeComponent();
        }

        public ResultsWindow(string workModel, double index, string classification, string recommendations)
            : this()
        {

            TitleTextBlock.Text = $"Resultado - Modelo {workModel}";
            IndexTextBlock.Text = $"Índice de Trabalho do Futuro: {index:F2}";
            ClassificationTextBlock.Text = classification;
            RecommendationsTextBlock.Text = recommendations;
        }

        private void OnCloseClick(object? sender, RoutedEventArgs e) => Close();
    }
}
