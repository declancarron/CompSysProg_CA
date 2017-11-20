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
using System.Collections.ObjectModel;

namespace Student_Housing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {



        //Create a new instance of SQL database connection
        dcarronHousingEntities db = new dcarronHousingEntities();

        //Global list used to contain all users
        List<User> userList = new List<User>();

        //Global list used to contain all buildings
        List<Building> buildingList = new List<Building>();

        //Global list used to contain all Maintenance Requests
        List<Maintenance> maintenanceList = new List<Maintenance>();

        /// <summary>
        /// User data ObservableCollection constructors
        /// </summary>
        private ObservableCollection<UserListData> _UserSummaryData = new ObservableCollection<UserListData>();
        
        public ObservableCollection<UserListData> UserSummaryDataCollection
        { get { return _UserSummaryData; } }

        public class UserListData
        {
            public string UserID { get; set; }
            public string UName { get; set; }
            public string Forename { get; set; }
            public string Surname { get; set; }
            public string Password { get; set; }
            public int AccessLevel { get; set; }

        }

        /// <summary>
        /// Building ObservableCollection constructors
        /// </summary>
        private ObservableCollection<BuildingListData> _BuildingSummaryData = new ObservableCollection<BuildingListData>();

        public ObservableCollection<BuildingListData> BuildingSummaryDataCollection
        { get { return _BuildingSummaryData; } }

        public class BuildingListData
        {
            public String BuildingID { get; set; }
            public String BuildingName { get; set; }
            public String VillageID { get; set; }
            public String Description { get; set; }
            public DateTime DateSurveyed { get; set; }
            public DateTime NextSurveyDue { get; set; }
        }

        /// User data ObservableCollection constructors
        /// </summary>
        private ObservableCollection<MaintenanceListData> _MaintenanceSummaryData = new ObservableCollection<MaintenanceListData>();

        public ObservableCollection<MaintenanceListData> MaintenanceSummaryDataCollection
        { get { return _MaintenanceSummaryData; } }

        public class MaintenanceListData
        {
            public String RequestID { get; set; }
            public String UserID { get; set; }
            public String BuildingID { get; set; }
            public String BuildingName { get; set; }
            public String ProblemDescription { get; set; }
            public DateTime SubmissionDate { get; set; }
            public String RequestStatus { get; set; }
            public DateTime RequestCompletionDate { get; set; }
            public String EmployeeID { get; set; }
            public String AssignedTo { get; set; }
        }


        //Global list used to contain all users
        
        public MainWindow()
        {
            InitializeComponent();
        }


        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            string username = txtStudentID.Text.Trim();
            //Password box is accessed using different commands to textbox
            string password = tbxPasswordBox.Password;
            //Check if inputted credentials are in SQL database        
            user = VerifyUserDetails(username, password);
            if (user.AccessLevel > 0) //user exists
            {
                //create a new instance of the Dashboard window
                Dashboard dashboard = new Dashboard();
                dashboard.Owner = this;
                dashboard.currentUser = user;
                this.Hide();
                dashboard.ShowDialog();
                
            }
            else
            {
                //User does not exist
                MessageBox.Show("Invalid user");
            }
        }

        private void PopulateCollection()
        {
            foreach (var user in UserSummaryDataCollection)
            {
                _UserSummaryData.Add(new UserListData
                {
                    AccessLevel = 0;
                                      
                  
                });
            }

        private void btnForgotPassword_Click(object sender, RoutedEventArgs e)
        {
            // declaring a new instanace of the Password Reset screen
            PwdResetScreen resetPassword = new PwdResetScreen();
            resetPassword.Owner = this;
            //hide the login dialog screen
            this.Hide();
            //show the password dialog box
            resetPassword.ShowDialog();

        }
    

 

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            //Close down application
            this.Close();

            //close out all running applications
            Environment.Exit(0);
        }

        private User VerifyUserDetails(string username, string password)
        {
            User verifiedUser = new User();

            foreach (var user in userList)
            {
                //If current user in userList List has ther same username and password
                //then the user exists
                if (user.UName == username && user.Password == password)
                {
                    //put the details of the verified user into the verifiedUser instance
                    verifiedUser = user;
                }
            }
            
            //Return the user details to the calling method
            return verifiedUser;
        }

        /// <summary>
        /// load the users deatilas from the Users database
        /// </summary>
        private void LoadUsers()
        {
           try
           {
              // clear the users list
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

        /// <summary>
        /// load building details from the buildings database
        /// </summary>
        private void LoadBuildings()
        {
            try
            {
                //clear the building list 
                buildingList.Clear();

                // loop through the buildings database
                foreach (var building in db.Buildings)
                {
                    buildingList.Add(building);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to database " + ex.InnerException);
            }

        }

        /// <summary>
        /// load the maintenance request  details from the maintenance database
        /// </summary>
        private void LoadMaintenanceReqs()
        {
            try
            {
                //clear the maintenance list
                maintenanceList.Clear();

                //loop through the maintenance database
                foreach (var maintenanceReq in db.Maintenances)
                {
                    maintenanceList.Add(maintenanceReq);
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
            LoadUsers();
            LoadBuildings();
            LoadMaintenanceReqs();
        }

        private void btnNewUser_Click(object sender, RoutedEventArgs e)
        {

        }



    }


}
