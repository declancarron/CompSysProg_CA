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
        dcarronHousingEntities2 db = new dcarronHousingEntities2();
        //Global list used to contain all users
        List<User> userList = new List<User>();

        //Global list used to contain all buildings
        List<Building> buildingList = new List<Building>();

        //Global list used to contain all Maintenance Requests
        List<Maintenance> maintenanceList = new List<Maintenance>();

        string entityState = "Modify";
        //

        //making the current user available
        public User currentUser;

        public PageSettings()
        {
            InitializeComponent();
        }

       

        /// <summary>
        /// following section is for user details, populating the listview
        /// making changes to selected user details
        /// </summary>
        /// <param name="selectedUser"></param>
        private void mtdPopulateUserDetails(User selectedUser)
        {
            dockUserPanel.Visibility = Visibility.Visible;
            tbkForename.Text = selectedUser.Forename;
            tbkSurname.Text = selectedUser.Surname;
            tbkPassord.Text = selectedUser.Password;
            tbkUName.Text = selectedUser.UName;

            //Access level for Nornal User
            if (selectedUser.AccessLevel == 1)
            {
                cboxAccessLevel.SelectedIndex = 0;
            }

            //Access level for Residents
            if (selectedUser.AccessLevel == 2)//A new record may need to be created and its index will =0
            {
                cboxAccessLevel.SelectedIndex = 1;
            }

            //Access level for Maintenance Staff
            if (selectedUser.AccessLevel == 3)//A new record may need to be created and its index will =0
            {
                cboxAccessLevel.SelectedIndex = 2;
            }

            //Access Level for Site Administrators
            if (selectedUser.AccessLevel == 4)//A new record may need to be created and its index will =0
            {
                cboxAccessLevel.SelectedIndex = 3;
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

        //make changes to the user details in user database record
        private void btnClick_UserUpdate(object sender, RoutedEventArgs e)
        {
            currentUser.Forename = tbkForename.Text.Trim();
            currentUser.Surname = tbkSurname.Text.Trim();
            currentUser.UName = tbkUName.Text.Trim();
            currentUser.Password = tbkPassord.Text.Trim();
            currentUser.AccessLevel = cboxAccessLevel.SelectedIndex;

            bool userVerified = mtdVerifyUserDetails(currentUser);
            if (userVerified)
            {
                mtdUpdateUser(currentUser, entityState);
                mtdPopulateUserTable();
                lstUsersList.Items.Refresh();
            }
            dockUserPanel.Visibility = Visibility.Collapsed;
        }

        //delete user details from the user database record
        private void btnClick_UserDelete(object sender, RoutedEventArgs e)
        {
            entityState = "Delete";
            mtdUpdateUser(currentUser, entityState);
            mtdPopulateUserTable();
            lstUsersList.Items.Refresh();
            dockUserPanel.Visibility = Visibility.Collapsed;
        }

        //cancel changes being made to user details in user database record
        private void btnClick_UserCancel(object sender, RoutedEventArgs e)
        {

        }
        private bool mtdVerifyUserDetails(User user)
        {
            bool userVerified = false;
            try
            {
                if (user.Forename == null)
                {
                    user.Forename = "";
                }
                if (user.Surname == null)
                {
                    user.Surname = "";
                }
                if (user.UName == null)
                {
                    user.UName = "";
                }
                if (user.Password == null)
                {
                    user.Password = "";
                }
                if (user.AccessLevel == -1)
                {
                    user.AccessLevel = 2;
                }
                userVerified = true;
            }
            catch (Exception)
            {

                MessageBox.Show("Problem verifying user");
            }
            return userVerified;
        }
        private void mtdUpdateUser(User user, string modifystate)
        {
            try
            {
                if (modifystate == "Add")
                {
                    user.UserID = Guid.NewGuid().ToString();//create new userid for database
                }
                if (modifystate == "Modify")
                {
                    foreach (var userRecord in db.Users.Where(t => t.UserID == user.UserID))
                    {
                        userRecord.Forename = user.Forename;
                        userRecord.Surname = user.Surname;
                        userRecord.UName = user.UName;
                        userRecord.Password = user.Password;
                        userRecord.AccessLevel = user.AccessLevel;
                        MessageBox.Show("User Record Modified");
                    }
                }
                if (modifystate == "Delete")
                {
                    db.Users.RemoveRange(db.Users.Where(t => t.UserID == user.UserID));
                    MessageBox.Show("User Record Deleted");
                }

                db.SaveChanges();
                db.Configuration.AutoDetectChangesEnabled = true;
                db.Configuration.ValidateOnSaveEnabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Problem writing to database");
                throw;
            }
        }

        private void mtdClearUserDetails()
        {
            tbkForename.Text = "";
            tbkSurname.Text = "";
            tbkUName.Text = "";
            tbkPassord.Text = "";
            cboxAccessLevel.SelectedIndex = 0;
        }

        private void mtdPopulateUserTable()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// following section is for building details, populating the listview
        /// making changes to selected building details
        /// </summary>
        /// <param name="selectedUser"></param>
        private void mtdPopulateBuildingDetails(Building selectedBuilding)
        {
            dockBuildingsPanel.Visibility = Visibility.Visible;
            tbkBuildingName.Text = selectedBuilding.BuildingName;
            tbkBuildingDescription.Text = selectedBuilding.Description;

            
            if (selectedBuilding.VillageName == "Grand Central")
            {
                cboBuildingVillage.SelectedIndex = 0;
            }
            if (selectedBuilding.VillageName == "Ballyraine Halls")//A new record may need to be created and its index will =0
            {
                cboBuildingVillage.SelectedIndex = 1;
            }

            if (selectedBuilding.VillageName == "Port Road Apartments")//A new record may need to be created and its index will =0
            {
                cboBuildingVillage.SelectedIndex = 2;
            }
            //tbkBuildingSurveyDate.Text = selectedBuilding.DateSurveyed;
           
        }

        private void lstBuildingsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String currentBuilding = "";

            if (buildingList.Count > 0)//Make sure a user record exists in the database
            {
                //Gets the user from the userList at the same position it is in within the ListView
               // currentBuilding = buildingList.ElementAt(this.lstBuildingsList.SelectedIndex);
               // mtdPopulateBuildingDetails(currentBuilding);
            }
        }

        //make changes to the buildings details in buildings database record
        private void btnClick_BuildingUpdate(object sender, RoutedEventArgs e)
        {

        }

        //delete buildings details in buildings database record
        private void btnClick_BuidingDelete(object sender, RoutedEventArgs e)
        {

        }

        //cancel changes being made to buildings details in buildings database record
        private void btnClick_BuildingCancel(object sender, RoutedEventArgs e)
        {

        }




        /// <summary>
        /// following section is for maintenance details, populating the listview
        /// making changes to selected maintenance details
        /// </summary>
        /// <param name="selectedMaintenance"></param>
        private void mtdPopulateMaintenanceDetails(Maintenance selectedMaintenance)
        {
            dockMaintenancePanel.Visibility = Visibility.Visible;
            tbkMaintenanceUserID.Text = selectedMaintenance.UserID;
            tbkMaintenanceBuildingID.Text = selectedMaintenance.BuildingID;
            tbkMaintenanceBuildingName.Text = selectedMaintenance.BuildingName;
            tbkMaintenanceDescription.Text = selectedMaintenance.ProblemDescription;
            tbkMaintenanceAssignedTo.Text = selectedMaintenance.AssignedTo;
            if (selectedMaintenance.RequestStatus == "Completed")
            {
                cboRequestStatus.SelectedIndex = 0;
            }
            if (selectedMaintenance.RequestStatus == "Work In Progress")//A new record may need to be created and its index will =0
            {
                cboRequestStatus.SelectedIndex = 1;
            }
            if (selectedMaintenance.RequestStatus == "Awaiting Part")
            {
                cboRequestStatus.SelectedIndex = 2;
            }
        }

        private void lstMaintenanceList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String currentMaintenanceReq = "";

            if (maintenanceList.Count > 0)//Make sure a user record exists in the database
            {
                //Gets the user from the userList at the same position it is in within the ListView
               // currentMaintenanceReq = maintenanceList.ElementAt(this.lstMaintenceList.SelectedIndex);
                //mtdPopulateMaintenanceDetails(currentMaintenanceReq);
            }
        }

        //make changes to the maintenance details in maintenance database record
        private void btnClick_btnMaintenanceUpdate(object sender, RoutedEventArgs e)
        {

        }

        //cancel changes being made to maintenance details in maintenance database record
        private void btnClick_nMaintenanceCancel(object sender, RoutedEventArgs e)
        {

        }

    }
}
