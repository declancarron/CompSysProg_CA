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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Create a new instance of SQL database connection
        dcarronHousingEntities db = new dcarronHousingEntities();
        //Global list used to contain all users
        List<Users> userList = new List<Users>();

        private ObservableCollection<User> lstUserSummaryData = new ObservableCollection<User>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Users user = new Users();
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

        private void btnForgotPassword_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            //Close down application
            this.Close();
        }

        private Users VerifyUserDetails(string username, string password)
        {
            Users verifiedUser = new Users();

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

        private void LoadUsers()
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
            LoadUsers();
        }

        private void btnNewUser_Click(object sender, RoutedEventArgs e)
        {

        }

        public class User
        {
            String UserID { get; set; }
            String UName { get; set; }
            String Forename { get; set; }
            String Surname { get; set; }
            String Password { get; set; }
            String AccessType { get; set; }
            String AccessLevel { get; set; }
            String Email { get; set; }
            String CountryCode { get; set; }
            String  MobileNum { get; set; }
            String Telephone { get; set; }
        }

        public class Building
        {
            String BuildingID { get; set; }
            String BuildingName { get; set; }
            String VillageID { get; set; }
            String Description { get; set; }
            DateTime DateSurveyed { get; set; }
            DateTime NextSurveyDue { get; set; }
        }

        public class Village
        {
            String VillageID  { get; set; }
            String Address1  { get; set; }
            String Street  { get; set; }
            String TownArea  { get; set; }
            String PostCode  { get; set; }
        }

        public class Resident
        {
            String ResidentID { get; set; }
            String UserID { get; set; }
            String College { get; set; }
            String Department { get; set; }
            String MartialStatus { get; set; }
            char  DepositPaid { get; set; }
            float DepositAmount { get; set; }
	        DateTime DepositPaymentDate { get; set; }
            float RefundDue { get; set; }
	        float RefundAmount { get; set; }
	        DateTime RefundPaymnetDate { get; set; }
	        DateTime RentDueDate { get; set; }
	        String RentFrequency { get; set; }
            float RentAmount { get; set; }
            float LastRentPaid { get; set; }
            float RentOverdue { get; set; }
            float RentArrears { get; set; }
        }
        public class Apartment
        {
            String CategoryID { get; set; }
            String BuildingID { get; set; }
            char AirCon { get; set; }
            String RoomType { get; set; }
            String Furnished { get; set; }
            char Dishwasher { get; set; }
        }

        public class Applicant
        {
            String ApplicantID { get; set; }
            String UserID { get; set; }
            String Forename { get; set; }
            String Surname { get; set; }
            String ApplicantsEmail { get; set; }
            String MobileNum { get; set; }
	        DateTime DOB { get; set; }
	        String PPSNumber { get; set; }
	        String Nationality { get; set; }
            String CountryOfBirth { get; set; }
            String Gender { get; set; }
            String  MartialStatus { get; set; }
            String ParentGardianName { get; set; }
	        String ParentGardianEmail { get; set; }
            String ParentGardianTelephone { get; set; }
            String College { get; set; }
            String Course { get; set; }
            String CourseYear { get; set; }
            String Department { get; set; }
            String VillagePreference { get; set; }
            String VillagePreference2 { get; set; }
            String VillagePreference3 { get; set; }
            String ApartmentCategoryPref1 { get; set; }
            String ApartmentCategoryPref2 { get; set; }
            String ApartmentCategoryPref3 { get; set; }
            String ApplicationStatus { get; set; }
	        String ApartmentOfferStatus { get; set; }
	        String ApartmentRejectCount { get; set; }
        }
    }
}
