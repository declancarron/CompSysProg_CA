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

namespace Housing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        dcarronHousingEntities db = new dcarronHousingEntities();

        ObservableCollection<User> UserSummaryData = new ObservableCollection<User>();

        List<User> userList = new List<User>();


        //lstUsersList.ItemsSource = userList;
        string entityState = "Modify";
        //

        //making the current user available
        public User currentUser;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new DataObject();
        }

        private void mtdLoadUsers()
        {
            try
            {
                userList.Clear();
                foreach (var user in db.Users)
                {
                    userList.Add(user);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to database " + ex.InnerException);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //do this first before any user interaction is allowed with this window
            mtdLoadUsers();
        }





        private void lstUsersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (userList.Count > 0)//make sure a user record exists in the dtabase
            {
                //Gets users from the userlist at the same position it is in within the ListView
                currentUser = userList.ElementAt(this.lstUsersList.SelectedIndex);
                mtdPopulateUserDetails(currentUser);
            }
        }

        private void mtdPopulateUserDetails(User selectedUser)
        {
            dockUserPanel.Visibility = Visibility.Visible;
            tbkForename.Text = selectedUser.Forename;
            tbkSurname.Text = selectedUser.Surname;
            tbkPassord.Text = selectedUser.Password;
            tbkUName.Text = selectedUser.UName;
            if (selectedUser.AccessLevel == 1)
            {
                cboAccessLevel.SelectedIndex = 0;
            }
            if (selectedUser.AccessLevel == 2)// a new record may need to be created
            {
                cboAccessLevel.SelectedLevel = 1;
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            currentUser.Forename = tbkForename.Text.Trim();
            currentUser.Surname = tbkSurname.Text.Trim();
            currentUser.UName = tbkUName.Text.Trim();
            currentUser.Password = tbkPassord.Text.Trim();
            currentUser.AccessLevel = cboAccessLevel.SelectedIndex;

            bool userVerified = mtdVerifyUserDetails(currentUser);
            if (userVerified)
            {
                mtdUpdateUser(currentUser, entityState);
                mtdPopulateUserTable();
                lstUsersList.Items.Refresh();
            }
            dockUserPanel.Visibility = Visibility.Collapsed;

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

        private void btAddUser_Click(object sender, RoutedEventArgs e)
        {
            dockUserPanel.Visibility = Visibility.Visible;
            mtdClearUserDetails();
            entityState = "Add";
        }

        private void mtdClearUserDetails()
        {
            tbkForename.Text = "";
            tbkSurname.Text = "";
            tbkUName.Text = "";
            tbkPassord.Text = "";
            cboAccessLevel.SelectedIndex = 0;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            entityState = "Delete";
            mtdUpdateUser(currentUser, entityState);
            mtdPopulateUserTable();
            lstUsersList.Items.Refresh();
            dockUserPanel.Visibility = Visibility.Collapsed;
        }

        private void mtdPopulateUserTable()
        {
            throw new NotImplementedException();
        }
    }
}
