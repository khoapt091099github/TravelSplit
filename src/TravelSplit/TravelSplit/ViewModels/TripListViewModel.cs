using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TravelSplit.Helpers;
using TravelSplit.Models;
using TravelSplit.View;

namespace TravelSplit.ViewModels
{
    public class TripListViewModel
    {
        public ObservableCollection<Trip> Trips { get; set; }
        public ICommand AddTripCommand { get; }


        public TripListViewModel()
        {
            Trips = new ObservableCollection<Trip>
            {
                new Trip
                {
                    Name        = "Da Lat Trip",
                    Destination = "Da Lat",
                    StartDate   = new DateTime(2026, 5, 1),
                    EndDate     = new DateTime(2026, 5, 5)
                },
                new Trip
                {
                    Name        = "Phu Quoc Beach",
                    Destination = "Phu Quoc",
                    StartDate   = new DateTime(2026, 7, 10),
                    EndDate     = new DateTime(2026, 7, 15)
                }
            };
            AddTripCommand = new RelayCommand(OpenAddTrip);

        }

        private void OpenAddTrip()
        {
            var window = new AddTripView();
            window.ShowDialog();

            if (window.ViewModel.Result != null)
                Trips.Add(window.ViewModel.Result);
        }
    }
}
