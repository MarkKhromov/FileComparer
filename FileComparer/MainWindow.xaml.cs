using System.Windows;

namespace FileComparer {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            DataContext = new MainWindowViewModel(this);
        }

        public string GetFileExtension(string fileName) {
            return fileName.Substring(fileName.LastIndexOf(".") + 1);
        }
    }
}