using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace VegaEditor
{
    /// <summary>
    /// Interaction logic for EnginePathDialog.xaml
    /// </summary>
    public partial class EnginePathDialog : Window
    {
        public string VegaPath { get; private set; }
        public EnginePathDialog()
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
        }

        private void OnOk_Button_Clicked(object sender, RoutedEventArgs e)
        {
            var path = pathTextBox.Text;
            messageTextBlock.Text = string.Empty;
            if(string.IsNullOrEmpty(path))
            {
                messageTextBlock.Text = "Invalid Path!";
            }
            else if (path.IndexOfAny(Path.GetInvalidPathChars()) != -1)
            {
                messageTextBlock.Text = "Path Contains Invalid Character(s)!";
            }
            else if (!Directory.Exists(Path.Combine(path, @"Engine\EngineAPI\")))
            {
                messageTextBlock.Text = "Unable To Find Engine API At Specified Location!";
            }

            if(string.IsNullOrEmpty(messageTextBlock.Text))
            {
                if (!Path.EndsInDirectorySeparator(path)) path += @"\";
                VegaPath = path;
                DialogResult = true;
                Close();
            }
        }
    }
}
