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

namespace Student_Housing
{
    /// <summary>
    /// Interaction logic for settingsPage.xaml
    /// </summary>
    /// 

    ///currentMaintenanceReq
    public partial class PageSettings : Page
    {

        //Global list used to contain all users
        List<User> userList = new List<User>();

        //Global list used to contain all buildings
        List<Building> buildingList = new List<Building>();

        //Global list used to contain all Maintenance Requests
        List<Maintenance> maintenanceList = new List<Maintenance>();


        public PageSettings()
        {
            InitializeComponent();
        }

        String currentUser = "";
        String currentBuilding = "";
        String currentMaintenanceReq = "";

        private void lstMaintenanceList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String currentMaintenanceReq = "";

            if (maintenanceList.Count > 0)//Make sure a user record exists in the database
            {
                //Gets the user from the userList at the same position it is in within the ListView
                currentMaintenanceReq = maintenanceList.ElementAt(this.lstMaintenceList.SelectedIndex);
                mtdPopulateMaintenanceDetails(currentMaintenanceReq);
            }
        }

        private void lstUsersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String currentUser = "";

            if (userList.Count > 0)//Make sure a user record exists in the database
            {
                //Gets the user from the userList at the same position it is in within the ListView
                currentUser = userList.ElementAt(this.lstUsersList.SelectedIndex);
                mtdPopulateUserDetails(currentUser);
            }
        }

        private void lstBuildingsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String currentBuilding = "";

            if (buildingList.Count > 0)//Make sure a user record exists in the database
            {
                //Gets the user from the userList at the same position it is in within the ListView
                currentBuilding = buildingList.ElementAt(this.lstUsersList.SelectedIndex);
                mtdPopulateBuildingDetails(currentBuilding);
            }
        }

        /// <summary>
        /// populate user details
        /// </summary>
        /// <param name="selectedUser"></param>
        private void mtdPopulateUserDetails(User selectedUser)
        {
            dockUserPanel.Visibility = Visibility.Visible;
            tbxUserForename.Text = selectedUser.Forename;
            tbxUserSurname.Text = selectedUser.Surname;
            tbxUserPassword.Text = selectedUser.Password;
            tbxUsername.Text = selectedUser.UserName;
            if (selectedUser.AccessLevel == 1)
            {
                cboAccessLevel.SelectedIndex = 0;
            }
            if (selectedUser.AccessLevel == 2)//A new record may need to be created and its index will =0
            {
                cboAccessLevel.SelectedIndex = 1;
            }
        }

        /// <summary>
        /// populate building details
        /// </summary>
        /// <param name="selectedUser"></param>
        private void mtdPopulateBuildingDetails(User selectedUser)
        {
            dockUserPanel.Visibility = Visibility.Visible;
            tbxUserForename.Text = selectedUser.Forename;
            tbxUserSurname.Text = selectedUser.Surname;
            tbxUserPassword.Text = selectedUser.Password;
            tbxUsername.Text = selectedUser.UserName;
            if (selectedUser.AccessLevel == 1)
            {
                cboAccessLevel.SelectedIndex = 0;
            }
            if (selectedUser.AccessLevel == 2)//A new record may need to be created and its index will =0
            {
                cboAccessLevel.SelectedIndex = 1;
            }
        }

        /// <summary>
        /// populate maintenance details
        /// </summary>
        /// <param name="selectedUser"></param>
        private void mtdPopulateMaintenanceDetails(User selectedMaintenance)
        {
            dockUserPanel.Visibility = Visibility.Visible;
            tbxUserForename.Text = selectedUser.Forename;
            tbxUserSurname.Text = selectedUser.Surname;
            tbxUserPassword.Text = selectedUser.Password;
            tbxUsername.Text = selectedUser.UserName;
            if (selectedUser.AccessLevel == 1)
            {
                cboAccessLevel.SelectedIndex = 0;
            }
            if (selectedUser.AccessLevel == 2)//A new record may need to be created and its index will =0
            {
                cboAccessLevel.SelectedIndex = 1;
            }
        }

    }
}
