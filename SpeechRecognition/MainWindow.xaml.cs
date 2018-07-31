using System.Windows;

namespace SpeechRecognition
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainViewModel();
        }

        private void MainWindow_OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainViewModel viewModel = DataContext as MainViewModel;

            if (viewModel != null)
            {
                viewModel.Dispose();
            }
        }
    }
}