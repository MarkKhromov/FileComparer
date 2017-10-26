using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;

namespace FileComparer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "txt files All files (*.*)|*.*";
            if (dialog.ShowDialog() == true)
            {
                string filename = dialog.FileName;
                //label1.Text = filename.Split('\\')[filename.Split('\\').Length - 1];
                using (var sr = new StreamReader(filename))
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
        public string getFileExtension(string fileName)
        {
            return fileName.Substring(fileName.LastIndexOf(".") + 1);
        }
    }
}
