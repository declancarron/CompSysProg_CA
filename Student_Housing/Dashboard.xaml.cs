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
        public Dashboard()
        {
            InitializeComponent();
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
