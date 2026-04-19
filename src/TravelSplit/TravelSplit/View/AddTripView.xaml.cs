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
using System.Windows.Shapes;
using TravelSplit.ViewModels;

namespace TravelSplit.View
{
    /// <summary>
    /// Interaction logic for AddTripView.xaml
    /// </summary>
    public partial class AddTripView : Window
    {
        public AddTripViewModel ViewModel { get; }

        public AddTripView()
        {
            InitializeComponent();

            ViewModel = new AddTripViewModel();
            DataContext = ViewModel;

            ViewModel.RequestClose += () => this.Close();
        }
    }
}
