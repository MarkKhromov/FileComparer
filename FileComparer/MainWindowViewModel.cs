using System.ComponentModel;
using System.IO;
using System.Windows.Input;
using Microsoft.Win32;

namespace FileComparer {
    class MainWindowViewModel : INotifyPropertyChanged {
        public MainWindowViewModel(MainWindow mainWindow) {
            this.mainWindow = mainWindow;
            loadFileCommand = new Command(LoadFile, () => true);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        readonly MainWindow mainWindow;

        readonly ICommand loadFileCommand;
        public ICommand LoadFileCommand { get { return loadFileCommand; } }
        string fileName;
        public string FileName {
            get { return fileName; }
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
                //label1.Text = filename.Split('\\')[filename.Split('\\').Length - 1];
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