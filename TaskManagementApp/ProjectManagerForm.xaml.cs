using BLLibrary;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace TaskManagementApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DatabaseInteraction _mv;

        public MainWindow()
        {
            _mv = new DatabaseInteraction(new TaskTrackerDBEntities());
            InitializeComponent();
            Loaded += (s, e) =>
            {
                _mv.Load();
                DataContext = _mv;
            };
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                if (MessageBox.Show("Save changes?", "Message", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    _mv.Save();
                    MessageBox.Show("Saved successfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

       
    }
}
