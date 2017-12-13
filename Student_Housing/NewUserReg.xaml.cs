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
    /// Interaction logic for NewUserReg.xaml
    /// </summary>
    public partial class NewUserReg : Window
    {
        //create a new instance of database
        dcarronHousingEntities2 db = new dcarronHousingEntities2();


        public NewUserReg()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbxNewUserPassword.Password == tbxNewUserConfirmPassword.Password)
                {
                    //add new user account for the details in the New User Registration
                    mtdAddNewUserDetails();

                    //clear the details entered so that the New User Form is blank
                    mtdClearUserDetails();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("The Passwords entered do not match");
            }
        }

        //method for adding the newly registered user to the user database
        private void mtdAddNewUserDetails()
        {
            try
            {
                db.Configuration.AutoDetectChangesEnabled = false;
                db.Configuration.ValidateOnSaveEnabled = false;
                db.Entry(mtdGetNewUser()).State = System.Data.Entity.EntityState.Added;

                db.SaveChanges();
                db.Configuration.AutoDetectChangesEnabled = true;
                db.Configuration.ValidateOnSaveEnabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("On Error occurred writing to the database");
            }
        }

        //method to get the user details from the new user registration page
        private User mtdGetNewUser()
        {
            //create a new instance of the user database
            User newRegisteredUser = new User();

            string newRegisteredUserpassword = tbxNewUserPassword.Password;
            string newRegisteredUserUName= tbxNewUserUName.Text.Trim().ToLower();

            //gather the new registered user details from the new user registration form
            //generate a unique userid for the new user using the Guid.NewGuid()
            newRegisteredUser.UserID = Guid.NewGuid().ToString();
            newRegisteredUser.Forename = tbxFName.Text.ToString();
            newRegisteredUser.Surname = tbxSName.Text.Trim();
            newRegisteredUser.Address = tbxHomeAddr.Text.Trim();
            newRegisteredUser.Town = tbxHomeTown.Text.Trim();
            newRegisteredUser.City = tbxHomeCity.Text.Trim();
            newRegisteredUser.County = tbxHomeCounty.Text.Trim();
            newRegisteredUser.MobileNum = tbxMobile.Text.Trim();
            newRegisteredUser.Email = tbxEmail.Text.Trim();
            newRegisteredUser.UName = newRegisteredUserUName;
            newRegisteredUser.Password = newRegisteredUserpassword;
            
            //define the access level of the new registered user is set to a normal user
            newRegisteredUser.AccessLevel = 1;

            return newRegisteredUser;

        }

        //method to clear the information from the new user registration form
        private void mtdClearUserDetails()
        {
            string tbxFName = "";
            string tbxSName = "";
            string tbxHomeAddr = "";
            string tbxHomeTown = "";
            string tbxHomeCity = "";
            string tbxHomeCounty = "";
            string tbxMobile = "";
            string tbxEmail = "";
            string tbxNewUserUName = "";
            string tbxNewUserPassword = "";
            string tbxNewUserConfirmPassword="";

        }

    }
}
