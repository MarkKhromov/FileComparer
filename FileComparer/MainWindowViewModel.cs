using System.ComponentModel;
using System.Windows.Input;

namespace FileComparer {
    class MainWindowViewModel : INotifyPropertyChanged {
        public MainWindowViewModel(MainWindow mainWindow) {
            mainWindowModel = new MainWindowModel(mainWindow, fileName);
            LoadFileCommand = new Command(mainWindowModel.LoadFile, () => true);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        readonly MainWindowModel mainWindowModel;

        public ICommand LoadFileCommand { get; }
        string fileName;
        public string FileName {
            get => fileName;
            set {
                fileName = value;
                RaisePropertyChanged(nameof(FileName));
            }
        }

        void RaisePropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}