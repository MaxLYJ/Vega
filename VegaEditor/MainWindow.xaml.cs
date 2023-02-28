using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using VegaEditor.GameProject;

namespace VegaEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string VegaPath { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnMainWindowLoaded;
            Closing += OnMainWindowClosing;
        }

        private void OnMainWindowClosing(object sender, CancelEventArgs e)
        {
            Closing -= OnMainWindowClosing;
            Project.Current?.Unload();
        }

        private void OnMainWindowLoaded(object sender, RoutedEventArgs e)
        {
            Loaded -= OnMainWindowLoaded;
            GetEnginePath();
            OpenProjectBrowserDialog();
        }

        private void GetEnginePath()
        {
            var vegaEnginePath = Environment.GetEnvironmentVariable("VEGA_ENGINE_PATH", EnvironmentVariableTarget.User);
            if (vegaEnginePath == null || !Directory.Exists(Path.Combine(vegaEnginePath, @"Engine\EngineAPI")))
            {
                var dlg = new EnginePathDialog();
                if(dlg.ShowDialog() == true)
                {
                    VegaPath = dlg.VegaPath;
                    Environment.SetEnvironmentVariable("VEGA_ENGINE_PATH", VegaPath.ToUpper(), EnvironmentVariableTarget.User);
                }
                else
                {
                    Application.Current.Shutdown();
                }
            }
            else
            {
                VegaPath = vegaEnginePath;
            }
        }

        private void OpenProjectBrowserDialog()
        {
            var projectBrowser = new ProjectBrowserDialog();
            if(projectBrowser.ShowDialog() == false || projectBrowser.DataContext == null)
            {
                Application.Current.Shutdown();
            }
            else
            {
                Project.Current?.Unload();
                DataContext = projectBrowser.DataContext;
            }
        }
    }
}
