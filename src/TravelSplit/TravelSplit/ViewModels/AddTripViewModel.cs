using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using TravelSplit.Helpers;
using TravelSplit.Models;

namespace TravelSplit.ViewModels
{
    public class AddTripViewModel
    {
        public string TripName { get; set; } = "";
        public string Destination { get; set; } = "";
        public DateTime StartDate { get; set; } = DateTime.Today;
        public DateTime EndDate { get; set; } = DateTime.Today.AddDays(3);

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public Trip? Result { get; private set; }

        public event Action? RequestClose;
        public AddTripViewModel()
        {
            SaveCommand = new RelayCommand(Save, CanSave);
            CancelCommand = new RelayCommand(Cancel);
        }

        private bool CanSave()
            => !string.IsNullOrWhiteSpace(TripName)
             && !string.IsNullOrWhiteSpace(Destination);
        private void Save()
        {
            Result = new Trip
            {
                Name = TripName,
                Destination = Destination,
                StartDate = StartDate,
                EndDate = EndDate
            };

            RequestClose?.Invoke();
        }
        private void Cancel()
        {
            Result = null;         
            RequestClose?.Invoke();
        }
    }
}
