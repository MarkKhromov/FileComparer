using System.ComponentModel;
using System.IO;
using System.Windows.Input;
using Microsoft.Win32;

namespace FileComparer {
    class MainWindowViewModel : INotifyPropertyChanged {
        public MainWindowViewModel(MainWindow mainWindow) {
            LoadFileCommand = new Command(LoadFile, () => true);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // TODO: Refactoring
        readonly MainWindow mainWindow;
        public ICommand LoadFileCommand { get; }
        string fileName;
        public string FileName {
            get => fileName;
            set {
                fileName = value;
                RaisePropertyChanged(nameof(FileName));
            }
        }

        void LoadFile() {
            var dialog = new OpenFileDialog {
                Filter = FilterStringBuilder.Build(FileFormats.Txt, FileFormats.All)
            };
            if(dialog.ShowDialog(mainWindow) == true) {
                FileName = dialog.FileName;
                using(var sr = new StreamReader(FileName)) {
                    //string line;
                    //while ((line = sr.ReadLine()) != null)
                    //{

                    //}
                }
            } else {
                //label1.Text = "Файл не выбран";
            }
        }

        void RaisePropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}