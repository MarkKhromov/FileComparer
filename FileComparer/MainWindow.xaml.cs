using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace FileComparer {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            DataContext = new Command(LoadFile, () => true);
        }

        void LoadFile() {
            var dialog = new OpenFileDialog();
            dialog.Filter = FilterStringBuilder.Build(FileFormats.Txt, FileFormats.All);
            if(dialog.ShowDialog(this) == true) {
                string filename = dialog.FileName;
                //label1.Text = filename.Split('\\')[filename.Split('\\').Length - 1];
                using(var sr = new StreamReader(filename)) {
                    //string line;
                    //while ((line = sr.ReadLine()) != null)
                    //{

                    //}
                }
            } else {
                //label1.Text = "Файл не выбран";
            }
        }
        public string GetFileExtension(string fileName) {
            return fileName.Substring(fileName.LastIndexOf(".") + 1);
        }
    }
}