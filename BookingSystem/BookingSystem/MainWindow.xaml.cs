using Entities;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Printing.IndexedProperties;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookingSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private List<Bookings> _allBookings;
        private List<Booker> _allBookers;
        public event PropertyChangedEventHandler? PropertyChanged;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Pitches = new ObservableCollection<Pitches>();
            Loaded += OnLoaded;
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<Pitches> pitches;

        public ObservableCollection<Pitches> Pitches
        {
            get { return pitches; }
            set 
            {
                pitches = value;
                OnPropertyChanged(nameof(Pitches));
            }
        }

        private ObservableCollection<Bookings> bookings;

        public ObservableCollection<Bookings> Bookings
        {
            get { return bookings; }
            set
            {
                bookings = value;
                OnPropertyChanged(nameof(Bookings));
            }
        }

        private ObservableCollection<Booker> booker;

        public ObservableCollection<Booker> Booker
        {
            get { return booker; }
            set
            {
                booker = value;
                OnPropertyChanged(nameof(Booker));
            }
        }


        public async void OnLoaded(object sender, RoutedEventArgs e)
        {
            BookingService service = new();

            string bookings = await service.GetBookings();
            string pitches = await service.GetPitches();
            string booker = await service.GetBookers();
            //BookingService? bookingService = JsonSerializer.Deserialize<BookingService>(bookings);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<Bookings> bookingresult = JsonSerializer.Deserialize<List<Bookings>>(bookings, options);
            List<Pitches> pitchresult = JsonSerializer.Deserialize<List<Pitches>>(pitches, options);
            List<Booker> bookerresult = JsonSerializer.Deserialize<List<Booker>>(booker, options);
            ObservableCollection<Pitches> pitches1 = new ObservableCollection<Pitches>(pitchresult as List<Pitches>);
            Pitches = pitches1;

            ObservableCollection<Bookings> bookings1 = new ObservableCollection<Bookings>(bookingresult as List<Bookings>);
            Bookings = bookings1;
            _allBookings = bookingresult;

            ObservableCollection<Booker> booker1 = new ObservableCollection<Booker>(bookerresult as List<Booker>);
            Booker = booker1;
            _allBookers = bookerresult;
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            string mail = txtEmail.Text;
            DateTime startdate = dpStartDate.SelectedDate ?? DateTime.Now;
            DateTime enddate = dpEndDate.SelectedDate ?? DateTime.Now;
            BookingService service = new();
            if (_allBookers.FirstOrDefault(b => b.Mail == mail) == null)
            {
                Booker booker = new Booker { Name = name, Mail = mail };
                await service.SendBookers(booker);
                string bookers = await service.GetBookers();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                _allBookers = JsonSerializer.Deserialize<List<Booker>>(bookers, options);
            }
            Pitches selectedPitch = (Pitches)lvPitches.SelectedItem;
            Booker existingBooker = _allBookers.FirstOrDefault(b => b.Mail == mail);
            Bookings newBooking = new Bookings { StartDate = startdate, EndDate = enddate, BookerId = existingBooker.Id, PitchId = selectedPitch.Id };
            await service.SendBooking(newBooking);
            OnLoaded(sender, e);
        }

        private void lvPitches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvPitches.SelectedItem == null || _allBookings == null) return;
            Pitches pitches = (Pitches)lvPitches.SelectedItem;
            List<Bookings> bookingsFiltered = _allBookings.Where(b => b.PitchId == pitches.Id).ToList();
            Bookings = new ObservableCollection<Bookings>(bookingsFiltered);
        }

        private void lvBookings_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvBookings.SelectedItem == null) return;
            Bookings bookings = (Bookings)lvBookings.SelectedItem;
            Booker? bookersFiltered = _allBookers.FirstOrDefault(b => b.Id == bookings.BookerId);
            if (bookersFiltered != null)
            {
                Booker = new ObservableCollection<Booker> { bookersFiltered };
            }
            txtName.Text = bookersFiltered.Name;
            txtEmail.Text = bookersFiltered.Mail;
            dpStartDate.SelectedDate = bookings.StartDate;
            dpEndDate.SelectedDate = bookings.EndDate;
        }
    }
}