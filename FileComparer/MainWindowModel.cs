using System.IO;
using Microsoft.Win32;

namespace FileComparer
{
    class MainWindowModel
    {
        public MainWindowModel(MainWindow mainWindow, string fileName)
        {
            this.mainWindow = mainWindow;
            this.fileName = fileName;
        }

        private readonly MainWindow mainWindow;
        private string fileName;

        public void LoadFile()
        {
            var dialog = new OpenFileDialog
            {
                Filter = FilterStringBuilder.Build(FileFormats.Txt, FileFormats.All)
            };
            if (dialog.ShowDialog(mainWindow) == true)
            {
                fileName = dialog.FileName;
                using (var sr = new StreamReader(fileName))
                {
                    //string line;
                    //while ((line = sr.ReadLine()) != null)
                    //{

                    //}
                }
            }
            else
            {
                //label1.Text = "Файл не выбран";
            }
        }
    }
}
