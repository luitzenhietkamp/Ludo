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
using ShowHideWpf;

namespace WPFInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Controls the main menu
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Initialise();
        }


        void Initialise()
        {
            var ShowHideInstance = new MainWindowViewModel();
            ShowHideInstance.ShowMenu = true;
        }

        /// <summary>
        /// Action when Exit button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit?", "Quitting game", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                this.Close();
            }
            
        }

        /// <summary>
        /// Action when Instructions button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InstructionsButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void InstructionsBackButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
