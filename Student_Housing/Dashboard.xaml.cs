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

namespace Student_Housing
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public User currentUser;

        public Dashboard()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            mtdShowButtons(currentUser.AccessLevel);
        }

        private void mtdShowButtons(int accessLevel)
        {
            //user-Applicant
            //buttons visible, Notifications, Apartment, Applicant, Profile
            if (accessLevel == 1)
            {
                btnNotification.Visibility = Visibility.Visible;
                btnApartment.Visibility = Visibility.Visible;
                btnApplicant.Visibility = Visibility.Visible;
                btnProfile.Visibility = Visibility.Visible;
            }

            //user-Resident
            //buttons visible, Notifications, Apartment, Resident, Profile
            if (accessLevel == 2)
            {
                btnNotification.Visibility = Visibility.Visible;
                btnApartment.Visibility = Visibility.Visible;
                btnResident.Visibility = Visibility.Visible;
                btnProfile.Visibility = Visibility.Visible;
            }

            //user-Maintenance
            //buttons visible, Notifications, Maintenance, and Profile
            if (accessLevel == 3)
            {
                btnNotification.Visibility = Visibility.Visible;
                btnMaintenance.Visibility = Visibility.Visible;
                btnProfile.Visibility = Visibility.Visible;
            }

            //user-Administrator
            //buttons visible, Notifications, Apartment, Applicant,Resident,Maintenance,Settings and Profile
            if (accessLevel == 4)
            {
                btnNotification.Visibility = Visibility.Visible;
                btnApartment.Visibility = Visibility.Visible;
                btnApplicant.Visibility = Visibility.Visible;
                btnResident.Visibility = Visibility.Visible;
                btnMaintenance.Visibility = Visibility.Visible;
                btnSettings.Visibility = Visibility.Visible;
                btnProfile.Visibility = Visibility.Visible;

            }
        }

        private void btnClickApartment(object sender, RoutedEventArgs e)
        {
            PageApartment apartment = new PageApartment();
            dashContentFrame.Navigate(apartment);
        }

        private void btnClickNotification(object sender, RoutedEventArgs e)
        {
            PageNotification notification  = new PageNotification();
            dashContentFrame.Navigate(notification);
        }

        private void btnClickApplicant(object sender, RoutedEventArgs e)
        {
            PageApplicant applicant = new PageApplicant();
            dashContentFrame.Navigate(applicant);
        }

        private void btnClickResident(object sender, RoutedEventArgs e)
        {
            PageResident resident = new PageResident();
            dashContentFrame.Navigate(resident);
        }

        private void btnClickMaintenance(object sender, RoutedEventArgs e)
        {
            PageMaintenanceRequests maintenance = new PageMaintenanceRequests();
            dashContentFrame.Navigate(maintenance);
        }

        private void btnClickSettings(object sender, RoutedEventArgs e)
        {
            PageSettings settings = new PageSettings();
            dashContentFrame.Navigate(settings);
        }

        private void btnClickProfile(object sender, RoutedEventArgs e)
        {
            PageProfile profile = new PageProfile();
            dashContentFrame.Navigate(profile);
        }

    }
}
