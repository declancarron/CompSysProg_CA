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
            //call the method show buttoms to display buttons
            //based on the users acces level
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
            //create a new instance of the Apartment Page
            PageApartment apartment = new PageApartment();

            //load the apartment page into the frame dashContentFrame
            dashContentFrame.Navigate(apartment);
        }

        private void btnClickNotification(object sender, RoutedEventArgs e)
        {
            //create a new instance of the Notification Page
            PageNotification notification  = new PageNotification();

            //load the notifications page into the frame dashContentFrame
            dashContentFrame.Navigate(notification);
        }

        private void btnClickApplicant(object sender, RoutedEventArgs e)
        {
            //create a new instance of the Applicant Page
            PageApplicant applicant = new PageApplicant();

            //load the applicant page into the frame dashContentFrame
            dashContentFrame.Navigate(applicant);
        }

        private void btnClickResident(object sender, RoutedEventArgs e)
        {
            //create a new instance of the Resident Page
            PageResident resident = new PageResident();

            //load the resident page into the frame dashContentFrame
            dashContentFrame.Navigate(resident);
        }

        private void btnClickMaintenance(object sender, RoutedEventArgs e)
        {
            PageMaintenanceRequests _maintenancePg = new PageMaintenanceRequests();

            //load the maintenance page into the frame dashContentFrame
            dashContentFrame.Navigate(_maintenancePg);
        }

        private void btnClickSettings(object sender, RoutedEventArgs e)
        {
            //create a new instance of the Setting Page
            PageSettings _settingsPg = new PageSettings();

            //load the settings page into the frame dashContentFrame
            dashContentFrame.Navigate(_settingsPg);
        }

        private void btnClickProfile(object sender, RoutedEventArgs e)
        {
            //create a new instance of the Profile Page
            PageProfile _profilePg = new PageProfile();
                
            //load the profile page into the frame dashContentFrame
            dashContentFrame.Navigate(_profilePg);
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            //Close the application
            this.Close();

            //close all running applications
            Environment.Exit(0);
        }
    }
}
